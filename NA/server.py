import requests
import xml.etree.ElementTree as ET
from flask import Flask, request
import base64
from sklearn.externals import joblib
import numpy as np
import warnings
import json

# Initialize the Flask application
app = Flask(__name__)

# Setting
NSCL_IP = 'localhost'
GSCL_IP = '<Please Enter GSCL IP Address>'
APP_NAME = 'FinalProject'
DATA_NAME = 'DATA'
NSCL_URL = ''
GSCL_URL = 'http://{}:8080/om2m/gscl/applications/{}/containers/{}/contentInstances'.format(GSCL_IP, APP_NAME, DATA_NAME)
NOTIFICATION_URL = 'http://localhost:5000/monitor' # Enter notification URL

sensorData = None
hmmBol = None
hmmPos = None
hmmObj = None
action = ['Brushing teeth', 'Washing', 'Cooking', 'Toileting', 'Using phone', 'Reading', 'Eating/Drinking', 'Sleeping']

# Subscribe GSCL
def subscribe():
    url = GSCL_URL + '/subscriptions'
    xml = "<om2m:subscription xmlns:om2m=\"http://uri.etsi.org/m2m\"><om2m:contact>{}</om2m:contact></om2m:subscription>".format(NOTIFICATION_URL)
    headers = {'Content-Type': 'application/xml'}
    response = requests.post(url, data=xml, headers=headers, auth=('admin', 'admin')).text
    root = ET.fromstring(response)
    if 'subscription' in root.tag:
        print('[Subscribe] Subscribed')
    else:
        print('[Subscribe] Error:', root.find('{http://uri.etsi.org/m2m}statusCode').text)

# Predict Activity
def predict():
    global sensorData

    bolData = sensorData['db'] + 2 * sensorData['ac'] + 4 * sensorData['window'] + 8 * sensorData['active']
    posData = sensorData['position']
    objData = sensorData['obj']
    
    bolY = hmmBol.predict(bolData)
    posY = hmmPos.predict(posData)
    objY = hmmObj.predict(objData)
    
    if bolY[0] == posY[0]:
        return bolY[0]
    elif bolY[0] == objY[0]:
        return bolY[0]
    elif posY[0] == objY[0]:
        return posY[0]
    else:
        return objY[0]

# Notification site
@app.route('/monitor', methods=['POST'])
def monitor():
    global sensorData
    data = request.data
    root = ET.fromstring(data)
    status = root.find('{http://uri.etsi.org/m2m}statusCode')
    if status.text == 'STATUS_CREATED':
        print('[Monitor] Status Created')
        
        # Get Representation
        rawContent = root.find('{http://uri.etsi.org/m2m}representation').text
        content = base64.b64decode(rawContent).decode("utf-8")
        root = ET.fromstring(content)
        
        # Get Content
        rawContent = root.find('{http://uri.etsi.org/m2m}content').text
        content = base64.b64decode(rawContent).decode("utf-8")
        root = ET.fromstring(content)
        
        # Get String
        strs = root.findall('str')
        rawData = dict()
        for str in strs:
            rawData[str.attrib['name']] = str.attrib['val']
        sensorData = json.loads(rawData['data'])
        print(sensorData)
    else:
        print('[Monitor]', status.text)
    return ''

# Check activity site
@app.route('/check', methods=['GET'])
def getData():
    print('[Get Data] Check Data')
    z = predict()
    return action[z]

# Main function
if __name__ == '__main__':
    warnings.simplefilter("ignore")
    subscribe()
    hmmBol = joblib.load('data/hmmBol.pkl')
    hmmPos = joblib.load('data/hmmPos.pkl')
    hmmObj = joblib.load('data/hmmObj.pkl')
    app.run(host='0.0.0.0', threaded=True)