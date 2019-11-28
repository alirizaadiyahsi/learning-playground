import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.linear_model import LinearRegression
from sklearn.model_selection import train_test_split

# linear regression model
linear_reg = LinearRegression()

# load data
df = pd.read_csv('house-prices.txt', header=None)

# rename columns
df.columns = ['Size', 'Bedroom', 'Price']

# removed unused column
df.drop('Bedroom', axis=1, inplace=True)

# get x and y axises X = Size, y = Price
X = df.Size.values.reshape(-1, 1)
y = df.Price.values.reshape(-1, 1)

# split data to test and train
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# find best fix prediction line
linear_reg.fit(X_train, y_train)

print(linear_reg.intercept_)
print(linear_reg.coef_)

# make prediction by using test data
y_head = linear_reg.predict(X_test)

# can be tested with custom test data
# also can be used original X and y values
X_test_custom = np.array([500, 4700]).reshape(-1, 1)
y_head_custom = linear_reg.predict(X_test_custom)

# draw a chart to see data points and prediction line
plt.scatter(X, y,  color='gray')
plt.plot(X_test_custom, y_head_custom, color='red', linewidth=1)
# plt.plot(X_test, y_head, color='red', linewidth=1)
plt.show()


