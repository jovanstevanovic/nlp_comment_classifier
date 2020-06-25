# Util classes
import pandas as pd


def percentage_calculator():
    # Reading data and remove unused
    # First comment set
    data_frame_1 = pd.read_csv("raw_data/comments_1.txt", sep="\t",
                               names=['NaturalLanguageID', 'ProgrammingLanguageName',
                                      'RepoID', 'SourceID', 'CommentID', 'Comment',
                                      'Type'])
    data_frame_1 = data_frame_1[['Comment', 'Type']]

    # Second comment set
    data_frame_2 = pd.read_csv("raw_data/comments_2.txt", sep="\t",
                               names=['NaturalLanguageID', 'ProgrammingLanguageName',
                                      'RepoID', 'SourceID', 'CommentID', 'Comment',
                                      'Type'])
    data_frame_2 = data_frame_2[['Comment', 'Type']]

    # Third comment set
    data_frame_3 = pd.read_csv("raw_data/comments_3.txt", sep="\t",
                               names=['NaturalLanguageID', 'ProgrammingLanguageName',
                                      'RepoID', 'SourceID', 'CommentID', 'Comment',
                                      'Type'])
    data_frame_3 = data_frame_3[['Comment', 'Type']]

    # Fourth comment set
    data_frame_4 = pd.read_csv("raw_data/comments_4.txt", sep="\t",
                               names=['NaturalLanguageID', 'ProgrammingLanguageName',
                                      'RepoID', 'SourceID', 'CommentID', 'Comment',
                                      'Type'])
    data_frame_4 = data_frame_4[['Comment', 'Type']]

    def convert_index_to_name(index):
        if index == 0:
            return "Vladimir Sivcev", data_frame_1
        if index == 1:
            return "Jovan Stevanovic", data_frame_2
        if index == 2:
            return "Predrag Mitrovic", data_frame_3
        if index == 3:
            return "Matija Lukic", data_frame_4

    sum_percentage = 0
    for i in range(0, 4):
        name1, df1 = convert_index_to_name(i)
        for j in range(i + 1, 4):
            name2, df2 = convert_index_to_name(j)
            print("{} - {}".format(name1, name2))

            tmp_data_frame = pd.concat([df1, df2]).drop_duplicates(keep=False)
            sum_percentage += 100 - tmp_data_frame.shape[0] / data_frame_1.shape[0] * 100
            print("Similarity: {:.2f}%".format(100 - tmp_data_frame.shape[0] / data_frame_1.shape[0] * 100))

    print("General similarity: {:.2f}%".format(sum_percentage / 6))
