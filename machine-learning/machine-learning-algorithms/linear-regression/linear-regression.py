import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.linear_model import LinearRegression

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

# find best fix prediction line
linear_reg.fit(X, y)

print(linear_reg.intercept_)
print(linear_reg.coef_)

# make prediction by using test data
y_head = linear_reg.predict(X)

# draw a chart to see data points and prediction line
plt.scatter(X, y, color='blue')
plt.plot(X, y_head, color='red', linewidth=1)
plt.show()


