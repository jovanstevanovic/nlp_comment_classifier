# Util classes
import re
import numpy as np
import pandas as pd
from nltk.corpus import stopwords

# Stemming classes
from nltk.stem import PorterStemmer
from nltk.tokenize import word_tokenize
from numpy import mean

# Preprocessing classes
from sklearn import preprocessing
from sklearn.feature_extraction.text import CountVectorizer, TfidfVectorizer, TfidfTransformer

# Global data
first_phase = False
current_preprocessing_type = 0

X = None
Y = None
X_test = None
Y_test = None

cv_unigram = None
cv_bigram = None
cv_trigram = None
tfidf_transformer = None
tf_transformer = None
idf_transformer = None
tfidf_vectorizer = None
tf_vectorizer = None


def set_data_set(data_set, is_test_set=False):
    global X, X_test
    if is_test_set:
        X_test = data_set
    else:
        X = data_set


def set_test_labels(data_set, is_test_set=False):
    global Y, Y_test
    if is_test_set:
        Y_test = data_set
    else:
        Y = data_set


def get_data_set():
    return X


def get_data_labels():
    return Y


def get_test_set():
    return X_test


def get_test_labels():
    return Y_test


def to_next_phase():
    global first_phase, current_preprocessing_type
    current_preprocessing_type = 0
    first_phase = not first_phase


def remove_string_special_characters(s):
    # removes special characters with ' '
    stripped = re.sub('[^a-zA-z\s]', ' ', s)
    stripped = re.sub('_', ' ', stripped)

    # Change any white space and new line to one space
    stripped = stripped.replace('\\n', ' ')
    stripped = re.sub('\s+', ' ', stripped)

    # Remove start and end white spaces
    stripped = stripped.strip()
    if stripped != '':
        return stripped


def bag_of_words_to_int_data_set(data_frame, is_test_data=False):
    global X, X_test, cv_unigram

    # Calculate matrix of occurrence for every word
    if is_test_data:
        X_test = cv_unigram.transform(data_frame['Comment'])
    else:
        X = cv_unigram.transform(data_frame['Comment'])


def init_global_variables():
    global cv_unigram, cv_bigram, cv_trigram, tf_transformer, tfidf_transformer, tfidf_vectorizer, tf_vectorizer

    data_frame = pd.read_csv("raw_data/comments.txt", sep="\t", names=['NaturalLanguageID', 'ProgrammingLanguageName',
                                                                       'RepoID', 'SourceID', 'CommentID', 'Comment',
                                                                       'Type'])
    data_frame = data_frame[['Comment', 'Type']]

    cv_unigram = CountVectorizer(ngram_range=(1, 1))
    unigram_counts = cv_unigram.fit_transform(data_frame['Comment'])

    cv_bigram = CountVectorizer(ngram_range=(2, 2))
    cv_bigram.fit(data_frame['Comment'])

    cv_trigram = CountVectorizer(ngram_range=(3, 3))
    cv_trigram.fit(data_frame['Comment'])

    tf_transformer = TfidfTransformer(use_idf=False)
    tf_transformer.fit(unigram_counts)

    tfidf_transformer = TfidfTransformer(use_idf=True)
    tfidf_transformer.fit(unigram_counts)

    tfidf_vectorizer = TfidfVectorizer(ngram_range=(1, 1), use_idf=True)
    tfidf_vectorizer.fit(data_frame['Comment'])

    tf_vectorizer = TfidfVectorizer(ngram_range=(1, 1), use_idf=False)
    tf_vectorizer.fit(data_frame['Comment'])

    data_frame.to_excel(r'preprocessed_data\all_comments.xlsx', index=False)


def preprocess_train_test_data(train_index, test_index):
    data_frame = pd.read_csv("raw_data/comments.txt", sep="\t", names=['NaturalLanguageID', 'ProgrammingLanguageName',
                                                                       'RepoID', 'SourceID', 'CommentID', 'Comment',
                                                                       'Type'])
    data_frame = data_frame[['Comment', 'Type']]

    df_train = pd.DataFrame(columns=['Comment', 'Type'])
    df_test = pd.DataFrame(columns=['Comment', 'Type'])

    df_train['Comment'], df_train['Type'] = data_frame['Comment'][train_index], data_frame['Type'][train_index]
    df_test['Comment'], df_test['Type'] = data_frame['Comment'][test_index], data_frame['Type'][test_index]

    df_train.to_excel(r'preprocessed_data\train_comments.xlsx', index=False)
    df_test.to_excel(r'preprocessed_data\test_comments.xlsx', index=False)

    do_preprocessing()


def do_preprocessing():
    if current_preprocessing_type == 0:
        without_preprocessing()
        without_preprocessing(is_test_data=True)

    if current_preprocessing_type == 1:
        lower_casing()
        lower_casing(is_test_data=True)

    if current_preprocessing_type == 2:
        tf()
        tf(is_test_data=True)

    if current_preprocessing_type == 3:
        idf()
        idf(is_test_data=True)

    if current_preprocessing_type == 4:
        tf_idf()
        tf_idf(is_test_data=True)

    if current_preprocessing_type == 5:
        stemmering()
        stemmering(is_test_data=True)

    if current_preprocessing_type == 6:
        frequency_word_filtering()
        frequency_word_filtering(is_test_data=True)

    if current_preprocessing_type == 7:
        bigram()
        bigram(is_test_data=True)

    if current_preprocessing_type == 8:
        trigram()
        trigram(is_test_data=True)


def prepare_type_for_first_phase(t):
    if t in {'Functional-Inline', 'Functional-Method', 'Functional-Module'}:
        t = 'Functional'
    return t


def remove_outliers(data_frame):
    global cv_unigram

    # Count unigrams with CountVectorizer
    unigram_counts = cv_unigram.transform(data_frame['Comment']).toarray()

    # Count number of words and mean number of words per data frame row
    number_of_words = 0
    for row_index, row in enumerate(unigram_counts):
        for column_index, column in enumerate(row):
            if unigram_counts[row_index][column_index] > 0:
                number_of_words += unigram_counts[row_index][column_index]

    mean_num_words = number_of_words / data_frame.shape[0]

    def cut_long_outlier(comment):
        words = word_tokenize(comment)
        return "".join([word + " " for index, word in enumerate(words) if index <= mean_num_words])

    data_frame['Comment'] = data_frame['Comment'].apply(cut_long_outlier)

    return data_frame


def init_preprocessing(is_test_data=False):
    # Reading data and remove unused
    if is_test_data:
        data_frame = pd.read_excel(r"preprocessed_data\test_comments.xlsx", names=['Comment', 'Type'])
    else:
        data_frame = pd.read_excel(r"preprocessed_data\train_comments.xlsx", names=['Comment', 'Type'])

    # Remove NA values, special characters, outliers, duplicates.
    data_frame = data_frame.dropna()
    data_frame['Comment'] = data_frame['Comment'].apply(remove_string_special_characters)
    if first_phase:
        data_frame['Type'] = data_frame['Type'].apply(prepare_type_for_first_phase)
    data_frame = remove_outliers(data_frame)

    # Transforming types to integer values
    if first_phase:
        labels = ['Functional', 'ToDo', 'Notice', 'General', 'Code', 'IDE']
    else:
        labels = ['Functional-Inline', 'Functional-Method', 'Functional-Module', 'ToDo', 'Notice', 'General', 'Code',
                  'IDE']
    label_encoder = preprocessing.LabelEncoder()
    label_encoder.fit(labels)
    data_frame['Type'] = label_encoder.transform(data_frame['Type'])

    set_test_labels(data_frame['Type'], is_test_data)

    return data_frame


def without_preprocessing(is_test_data=False):
    data_frame = init_preprocessing(is_test_data)
    bag_of_words_to_int_data_set(data_frame, is_test_data)

    if not is_test_data:
        data_frame.to_excel(r'preprocessed_data\comments_no_preprocessing.xlsx', index=False)


def lower_casing(is_test_data=False):
    data_frame = init_preprocessing(is_test_data)
    data_frame['Comment'] = data_frame['Comment'].apply(lambda comment: comment.lower())
    bag_of_words_to_int_data_set(data_frame, is_test_data)

    if not is_test_data:
        data_frame.to_excel(r'preprocessed_data\comments_lower_casing.xlsx', index=False)


def tf(is_test_data=False):
    global cv_unigram, tf_transformer

    data_frame = init_preprocessing(is_test_data)

    # Count unigrams with CountVectorizer
    unigram_counts = cv_unigram.transform(data_frame['Comment'])

    # Calculate TF value for each comment
    tf_counts = tf_transformer.transform(unigram_counts)

    # Set new data set
    set_data_set(tf_counts, is_test_data)

    if not is_test_data:
        data_frame.to_excel(r'preprocessed_data\comments_tf.xlsx', index=False)


def idf(is_test_data=False):
    global cv_unigram, tf_transformer, tfidf_transformer

    data_frame = init_preprocessing(is_test_data)

    # Count unigrams with CountVectorizer
    unigram_counts = cv_unigram.transform(data_frame['Comment'])

    # Calculate IDF value for each comment, using formula IDF=TF_IDF / TF
    tf_idf_counts = tfidf_transformer.transform(unigram_counts).toarray()
    tf_counts = tf_transformer.transform(unigram_counts).toarray()
    tf_counts[tf_counts == 0] = 1

    idf_counts = np.divide(tf_idf_counts, tf_counts)

    # Set new data set
    set_data_set(idf_counts, is_test_data)

    if not is_test_data:
        data_frame.to_excel(r'preprocessed_data\comments_idf.xlsx', index=False)


def tf_idf(is_test_data=False):
    global cv_unigram, tfidf_vectorizer

    data_frame = init_preprocessing(is_test_data)

    # Calculate TF value for each comment
    tf_idf_counts = tfidf_vectorizer.transform(data_frame['Comment'])

    # Set new data set
    set_data_set(tf_idf_counts, is_test_data)

    if not is_test_data:
        data_frame.to_excel(r'preprocessed_data\comments_tf_idf.xlsx', index=False)


def stemmering(is_test_data=False):
    data_frame = init_preprocessing(is_test_data)
    ps = PorterStemmer()

    def tokenize_stem_and_remove_stop_words(comment):
        words = word_tokenize(comment)
        return "".join([ps.stem(word) + " " for word in words if word not in stopwords.words()])

    data_frame['Comment'] = data_frame['Comment'].apply(tokenize_stem_and_remove_stop_words)

    bag_of_words_to_int_data_set(data_frame, is_test_data)

    if not is_test_data:
        data_frame.to_excel(r'preprocessed_data\comments_porter_stemmer.xlsx', index=False)


def frequency_word_filtering(is_test_data=False):
    global tf_vectorizer

    data_frame = init_preprocessing(is_test_data)

    # Count unigrams with CountVectorizer
    tf_counts = tf_vectorizer.transform(data_frame['Comment']).toarray()
    features = tf_vectorizer.get_feature_names()

    # Mean TF value with correction factor
    mean_value = mean([elem for row in tf_counts for elem in row if (elem > 0)]) * 0.75

    # All values with frequency below mean value reset to zero.
    tf_counts[tf_counts < mean_value] = 0

    # Remove all element below mean value and store them in new data frame
    new_data_frame = pd.DataFrame(columns=['Comment', 'Type'])

    def create_unigrams_from_comments():
        for row_index, row in enumerate(tf_counts):
            for column_index, column in enumerate(row):
                if column >= mean_value:
                    new_data_frame.loc[0 if pd.isnull(new_data_frame.index.max()) else new_data_frame.index.max() + 1] \
                        = [features[column_index], list(data_frame['Type'])[row_index]]

    create_unigrams_from_comments()
    new_data_frame = new_data_frame.drop_duplicates()

    # Set new data set
    set_data_set(tf_counts, is_test_data)

    if not is_test_data:
        data_frame.to_excel(r'preprocessed_data\comments_frequency_word_filtering.xlsx', index=False)
        new_data_frame.to_excel(r'preprocessed_data\comments_frequency_word_filtering_view.xlsx', index=False)


def bigram(is_test_data=False):
    global cv_bigram

    data_frame = init_preprocessing(is_test_data)

    bigram_counts = cv_bigram.transform(data_frame['Comment'])
    bigram_counts_indices = bigram_counts.toarray()
    features = cv_bigram.get_feature_names()

    new_data_frame = pd.DataFrame(columns=['Comment', 'Type'])

    def create_bigrams_from_comments():
        for row_index, row in enumerate(bigram_counts_indices):
            for column_index, column in enumerate(row):
                if column == 1:
                    new_data_frame.loc[0 if pd.isnull(new_data_frame.index.max()) else new_data_frame.index.max() + 1] \
                        = [features[column_index], list(data_frame['Type'])[row_index]]

    create_bigrams_from_comments()
    new_data_frame = new_data_frame.drop_duplicates()

    # Set new data set.
    set_data_set(bigram_counts, is_test_data)

    if not is_test_data:
        data_frame.to_excel(r'preprocessed_data\comments_bigram.xlsx', index=False)
        new_data_frame.to_excel(r'preprocessed_data\comments_bigrams_view.xlsx', index=False)


def trigram(is_test_data=False):
    global cv_trigram

    data_frame = init_preprocessing(is_test_data)

    trigram_counts = cv_trigram.transform(data_frame['Comment'])
    trigram_transform_indices = trigram_counts.toarray()
    features = cv_trigram.get_feature_names()

    new_data_frame = pd.DataFrame(columns=['Comment', 'Type'])

    def create_trigrams_from_comments():
        for row_index, row in enumerate(trigram_transform_indices):
            for column_index, column in enumerate(row):
                if column == 1:
                    new_data_frame.loc[0 if pd.isnull(new_data_frame.index.max()) else new_data_frame.index.max() + 1] \
                        = [features[column_index], list(data_frame['Type'])[row_index]]

    create_trigrams_from_comments()
    new_data_frame = new_data_frame.drop_duplicates()

    # Set new data set.
    set_data_set(trigram_counts, is_test_data)

    if not is_test_data:
        data_frame.to_excel(r'preprocessed_data\comments_trigram.xlsx', index=False)
        new_data_frame.to_excel(r'preprocessed_data\comments_trigrams_view.xlsx', index=False)
