# Util classes
import pandas as pd
import numpy as np

# Classifier class
from sklearn.model_selection import StratifiedShuffleSplit
from sklearn.linear_model import LogisticRegression
from nested_cv import NestedCV
from sklearn.metrics import f1_score

# Data set
import preprocessing.preprocessing as preprocessing


def compare_regularisation_functions(data_frame, rf, c=1.0):
    sss = StratifiedShuffleSplit(n_splits=10, test_size=0.1)
    index = 1
    average = 0
    for train_index, test_index in sss.split(data_frame['Comment'], data_frame['Type']):
        preprocessing.preprocess_train_test_data(train_index, test_index)

        if rf == 'l1':
            solver = 'saga'
        else:
            solver = 'lbfgs'

        lr = LogisticRegression(penalty=rf, C=c, solver=solver, max_iter=15000)
        lr.fit(preprocessing.get_data_set(), preprocessing.get_data_labels())
        score = f1_score(preprocessing.get_test_labels(), lr.predict(preprocessing.get_test_set()), average='weighted')

        average = average + score
        print("Score({}) {}.: {:.2f}%".format(rf.upper(), index, score * 100), end=" ")

        if index == 5:
            print()
        index += 1

    print()
    print("Average: {:.2f}%".format(average / 10 * 100))


def optimize_c_parameter():
    models_param = {
        'max_iter': [15000],
        'C': [0.0001, 0.001, 0.01, 0.1, 1, 10, 100, 1000]
    }

    nested_cv_search = NestedCV(model=LogisticRegression(), params_grid=models_param,
                                outer_kfolds=5, inner_kfolds=5,
                                cv_options={'sqrt_of_score': True, 'randomized_search_iter': 30})

    nested_cv_search.fit(preprocessing.get_data_set(), preprocessing.get_data_labels())

    optimized_c_value = np.mean([d['C'] for d in nested_cv_search.best_inner_params_list])
    print("Optimized C: {:.3f}".format(optimized_c_value))


def logistic_regression(which_comments):
    print("=> Logistic regression")
    data_frame = pd.read_excel(r'preprocessed_data\all_comments.xlsx')

    # Testing differences between regularisation functions
    print("> L1/L2 comparing")
    compare_regularisation_functions(data_frame, 'l1')
    compare_regularisation_functions(data_frame, 'l2')

    # Optimizing C parameter
    print("> Results with optimized C parameter")
    optimize_c_parameter()
