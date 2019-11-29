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

normalized_df = (df-df.mean())/df.std()

# get x and y axises X = Size, y = Price
X = np.array((normalized_df.iloc[:, 0:2]))
y = normalized_df.Price.values.reshape(-1, 1)

# find best fix prediction line
linear_reg.fit(X, y)

print(linear_reg.intercept_)
print(linear_reg.coef_)

# make prediction by using test data
y_head = linear_reg.predict(X)


# draw a chart to see data points and prediction line
plt.scatter(X[:, 0:1], y, color='blue')
plt.scatter(X[:, 1:2], y, color='red', linewidth=1)

plt.scatter(X[:, 0:1], y_head, color='gray', alpha=0.5)
plt.scatter(X[:, 1:2], y_head, color='yellow', linewidth=1, alpha=0.5)
plt.show()


