# Util classes
import pandas as pd

# Classifier class
from sklearn.model_selection import StratifiedShuffleSplit
from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import f1_score

# Data set
import preprocessing.preprocessing as preprocessing


def multinomial_nb(which_comments):
    print("=> Multinomial Bayes naive classifier")

    data_frame = pd.read_excel(r'preprocessed_data\all_comments.xlsx')

    sss = StratifiedShuffleSplit(n_splits=10, test_size=0.1)
    index = 1
    average = 0
    for train_index, test_index in sss.split(data_frame['Comment'], data_frame['Type']):
        preprocessing.preprocess_train_test_data(train_index, test_index)

        mnb = MultinomialNB()
        mnb.fit(preprocessing.get_data_set(), preprocessing.get_data_labels())
        score = f1_score(preprocessing.get_test_labels(), mnb.predict(preprocessing.get_test_set()), average='weighted')
        average = average + score

        print("Score {}.: {:.2f}%".format(index, score * 100), end=" ")
        if index == 5:
            print()
        index += 1

    print()
    print("Average: {:.2f}%".format(average / 10 * 100))
