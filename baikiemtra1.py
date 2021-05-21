import pandas as pd 
import numpy as np
import matplotlib.pyplot as plt


df_diabetes = pd.read_csv("diabetes.csv") 
X = df_diabetes.drop(['Outcome'],axis=1)
y=df_diabetes["Outcome"]
Age=df_diabetes[["Age"]]
Insulin=df_diabetes[["Insulin"]]
X2=df_diabetes[['BMI','Age']]
X1 = df_diabetes.iloc[:10,:]
X3=df_diabetes.iloc[5:6,:]
#1
print(X1)
#2
print(X.shape)
print(y.shape)
#3
print(X3)
#4
print(np.min(Age))
print(np.max(Age))
print(np.mean(Age))
print(np.var(Age))
print(np.std(Age))
#5
from sklearn import preprocessing as pp
mms = pp.MinMaxScaler() 
data_mms = mms.fit_transform(Insulin) 
print(data_mms) 
#6
def display_diabets(X3, text):
    X10 = X2[df_diabetes.Outcome == 0]
    X11 = X2[df_diabetes.Outcome == 1]

    plt.plot(X10["BMI"],X10["Age"], 'b^', markersize = 4, alpha = .8)
    plt.plot(X11["BMI"],X11["Age"], 'go', markersize = 4, alpha = .8)

    plt.xlabel('BMI')
    plt.xlabel('Age')
    plt.title(text)
    plt.plot()
    plt.show()
display_diabets(X2, 'diabetes dataset')
#7
print ('0:', y[y == 0].shape[0]) 
print ('1:', y[y == 1].shape[0])

#8

y20 = df_diabetes.iloc[:, 8].values
X21 = df_diabetes.drop(["Outcome"],axis=1).values

from sklearn.decomposition import PCA
colors = ['r^','bo']
def PCA_diabetes(X,y,text):
    X_new = PCA(2).fit_transform(X)
    print (X_new.shape)
    colors = ['r', 'b']
    markers = ['^', 'o']
    for l, c, m in zip(np.unique(y), colors, markers):
        plt.scatter(X_new[y==l, 0], X_new[y==l, 1], c=c, label=l, marker=m)
    plt.title(text) 
    plt.show()
PCA_diabetes(X21,y20,"PCA_Diabetes")

#9
from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=35)
print("Tập huấn luyện: ")
print(X_train.shape)
print(y_train.shape)
print("Tập test: ")
print(X_test.shape)
print(y_test.shape)
