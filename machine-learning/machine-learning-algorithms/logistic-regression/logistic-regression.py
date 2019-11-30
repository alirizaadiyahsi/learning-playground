import pandas as pd
import seaborn as sns
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression

titanicData = pd.read_csv('train.csv')

# show missing data
# sns.heatmap(train.isnull(), yticklabels=False, cbar=False, cmap='viridis')

sns.set_style('whitegrid')

# count-plot of people survived
# sns.countplot(x='Survived', hue='Sex', data=train, palette='RdBu_r')

# no. of people who survived according to their Passenger Class
# sns.countplot(x='Survived', hue='Pclass', data=train)

# distribution plot of age of the people
# sns.distplot(train['Age'].dropna(), kde=False, bins=30, color='Green')

# countplot of the people having siblings or spouce
# sns.countplot(x='SibSp', data=train)

# distribution plot of the ticket fare
# train['Fare'].hist(color='green', bins=40, figsize=(8, 4))

# boxplot with age on y-axis and Passenger class on x-axis.
# plt.figure(figsize=(12, 7))
# sns.boxplot(x='Pclass', y='Age', data=train, palette='winter')

def impute_age(cols):
    Age = cols[0]
    Pclass = cols[1]

    if pd.isnull(Age):
        if Pclass == 1:
            return 37
        elif Pclass == 2:
            return 29
        else:
            return 24
    else:
        return Age


titanicData['Age'] = titanicData[['Age', 'Pclass']].apply(impute_age, axis=1)

# lets see heat map again for missing values
# sns.heatmap(train.isnull(), yticklabels=False, cbar=False, cmap='viridis')

titanicData.drop('Cabin', axis=1, inplace=True)
titanicData.head()

# convert sex and embark columns to integer
sex = pd.get_dummies(titanicData['Sex'], drop_first=True)
embark = pd.get_dummies(titanicData['Embarked'], drop_first=True)

# drop the sex,embarked,name and tickets columns
titanicData.drop(['Sex', 'Embarked', 'Name', 'Ticket'], axis=1, inplace=True)

# concatenate new sex and embark column to our train dataframe
titanicData = pd.concat([titanicData, sex, embark], axis=1)

X_train, X_test, y_train, y_test = train_test_split(titanicData.drop('Survived', axis=1), titanicData['Survived'], test_size=0.30, random_state=101)

# create an instance and fit the model
logModel = LogisticRegression()
logModel.fit(X_train, y_train)

# predictions
Predictions = logModel.predict(X_test)