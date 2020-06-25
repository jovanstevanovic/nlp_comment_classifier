import preprocessing.preprocessing as preprocessing
import percentage_calc.percentage_calc as percentage_calc
import classifiers.multinomial_NB as multinomialNB
import classifiers.bernoulli_NB as bernoulliNB
import classifiers.SVC as SVC
import classifiers.logistic_regression as logistic_regression


def print_divide_line():
    length_of_divide_line = 110
    print("-" * length_of_divide_line)


def apply_all_classifiers(which_comments):
    # 1.
    multinomialNB.multinomial_nb(which_comments)

    # 2.
    bernoulliNB.bernoulli_nb(which_comments)

    # 3.
    SVC.support_vector_classifier(which_comments)

    # 4.
    logistic_regression.logistic_regression(which_comments)

    preprocessing.current_preprocessing_type = preprocessing.current_preprocessing_type + 1


def main_execution():
    preprocessing.init_global_variables()

    for i in range(2):
        preprocessing.to_next_phase()
        if i == 0:
            # First phase
            print("===> First phase")
        else:
            # Second phase
            print(sep="\n\n")
            print("===> Second phase")

        # 1.
        print("==> No preprocessing")
        apply_all_classifiers("comments_no_preprocessing.xlsx")
        print_divide_line()

        # 2.
        print("==> Lower casing")
        apply_all_classifiers("comments_lower_casing.xlsx")
        print_divide_line()

        # 3.
        print("==> Term Frequency")
        apply_all_classifiers("comments_tf.xlsx")
        print_divide_line()

        # 4.
        print("==> Inverse Document Frequency")
        apply_all_classifiers("comments_idf.xlsx")
        print_divide_line()

        # 5.
        print("==> Term Frequency–Inverse Document Frequency")
        apply_all_classifiers("comments_tf_idf.xlsx")
        print_divide_line()

        # 6.
        print("==> PorterStemmer")
        apply_all_classifiers("comments_porter_stemmer.xlsx")
        print_divide_line()

        # 7.
        print("==> Frequency word filtering")
        apply_all_classifiers("comments_frequency_word_filtering.xlsx")
        print_divide_line()

        # 8.
        print("==> Bigram preprocessing")
        apply_all_classifiers("comments_bigram.xlsx")
        print_divide_line()

        # 9.
        print("==> Trigram preprocessing")
        apply_all_classifiers("comments_trigram.xlsx")
        print_divide_line()


if __name__ == "__main__":
    option = int(input("Choose option? \n"
                       "0 - main execution \n"
                       "1 - calculate comment annotation similarity \n"))

    if option == 0:
        main_execution()
    else:
        percentage_calc.percentage_calculator()
