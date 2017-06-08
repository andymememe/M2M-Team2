import numpy as np
from hmmlearn.hmm import MultinomialHMM
import matplotlib.pyplot as plt
from sklearn.externals import joblib

# States
## 0 Brushing teeth
## 1 Washing
## 2 Cooking
## 3 Toileting
## 4 Using phone
## 5 Reading
## 6 Eating/Drinking
## 7 Sleeping
# Features:
## 0 Sound
## 1 AC
## 2 Windows
## 3 Active
## 4 Position --> 0: Liv,  1: Bed,   2: Kitchen, 3: Dining, 4: Toilet
## 5 Object   --> 0: None, 1: Phone, 2: Book,    3:Knife,   4: Fork,  5: Spoon, 6: Pot, 7: Toothbrush, 8: Towel

hmmBol = MultinomialHMM(n_components=8)
hmmPos = MultinomialHMM(n_components=8)
hmmObj = MultinomialHMM(n_components=8)

# Properties
startprob = np.array([ 0.125, 0.125, 0.125, 0.125, 0.125, 0.125, 0.125, 0.125])
transmat = np.array([[  0.3,  0.2,  0.1, 0.04, 0.03, 0.03,  0.2,  0.1],
                     [  0.2,  0.3,  0.1, 0.04, 0.03, 0.03,  0.2,  0.1],
                     [ 0.05,  0.1,  0.3,  0.1, 0.05, 0.05,  0.3, 0.05],
                     [ 0.06,  0.3, 0.06,  0.3, 0.06, 0.06, 0.06,  0.1],
                     [ 0.08, 0.08, 0.08, 0.08,  0.3,  0.2, 0.08,  0.1],
                     [ 0.08, 0.08, 0.08, 0.08,  0.2,  0.3, 0.08,  0.1],
                     [  0.3,  0.2,  0.0,  0.1, 0.03, 0.03,  0.3, 0.04],
                     [ 0.25, 0.25,  0.0, 0.25,  0.0,  0.0,  0.0, 0.25]])

# Boolean HMM
emmBol = np.array([[ 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0],
                   [ 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.9, 0.1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0],
				   [ 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.8, 0.0, 0.0, 0.0, 0.2],
				   [ 0.0, 0.0, 0.6, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.4, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0],
				   [ 0.0, 0.0, 0.2, 0.0, 0.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.2, 0.0, 0.3, 0.0, 0.0, 0.0],
				   [ 0.0, 0.0, 0.3, 0.0, 0.7, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0],
				   [ 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.6, 0.4, 0.0, 0.0],
				   [ 0.0, 0.0, 0.2, 0.0, 0.8, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0]])
hmmBol.n_features = 16
hmmBol.startprob_ = startprob
hmmBol.transmat_ = transmat
hmmBol.emissionprob_ = emmBol

# Position HMM
emmPos = np.array([[ 0.0, 0.0, 0.0, 0.0, 1.0],
                   [ 0.0, 0.0, 0.0, 0.0, 1.0],
                   [ 0.0, 0.0, 0.3, 0.7, 0.0],
                   [ 0.0, 0.0, 0.0, 0.0, 1.0],
                   [ 0.5, 0.5, 0.0, 0.0, 0.0],
                   [ 0.5, 0.5, 0.0, 0.0, 0.0],
                   [ 0.0, 0.0, 0.8, 0.2, 0.0],
                   [ 0.0, 1.0, 0.0, 0.0, 0.0]])
hmmPos.n_features = 5
hmmPos.startprob_ = startprob
hmmPos.transmat_ = transmat
hmmPos.emissionprob_ = emmPos

# Object HMM
emmObj = np.array([[ 0.1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.9, 0.0],
                   [ 0.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.7],
                   [ 0.0, 0.0, 0.0, 0.3, 0.2, 0.2, 0.3, 0.0, 0.0],
                   [ 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0],
                   [ 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0],
                   [ 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0],
                   [ 0.0, 0.0, 0.0, 0.3, 0.4, 0.3, 0.0, 0.0, 0.0],
                   [ 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0]])
hmmObj.n_features = 9
hmmObj.startprob_ = startprob
hmmObj.transmat_ = transmat
hmmObj.emissionprob_ = emmObj

# Export models
joblib.dump(hmmBol, "data/hmmBol.pkl")
joblib.dump(hmmPos, "data/hmmPos.pkl")
joblib.dump(hmmObj, "data/hmmObj.pkl")