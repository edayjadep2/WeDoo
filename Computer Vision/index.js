'use strict';

const request = require('request');
const multer = require('multer');
const upload = multer();

// Replace <Subscription Key> with your valid subscription key.
const subscriptionKey = '1ac451c12e4d43158dff30961082e4e9';

// You must use the same location in your REST call as you used to get your
// subscription keys. For example, if you got your subscription keys from
// westus, replace "westcentralus" in the URL below with "westus".
const uriBase =
    'https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/analyze';

const imageUrl =
    'http://upload.wikimedia.org/wikipedia/commons/3/3c/Shaki_waterfall.jpg';

// Request parameters.
const params = {
    'visualFeatures': 'Categories,Description,Color,Faces',
    'details': '',
    'language': 'en'
};

const cv = require('customvision-api');
const microsofComputerVision = require("microsoft-computer-vision");
const cognitiveServices = require('cognitive-services');
const express = require('express');
const formidable = require('formidable');
const fs = require('fs');
const app = express();
const port = 3000;
const config = {
    "predictionEndpoint": "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.0/Prediction/a7c710c2-2a7a-40e9-a779-d95d25a0c4e2/image",
    "predictionKey": "41be65b6f59c4667a7344f74c2ac1fdb"
};

app.post('/analyzeImage4', (req, res) => {
    var form = new formidable.IncomingForm();
    form.parse(req, function (err, fields, files) {
        cv.sendImage(
            files.imageFile.path,
            config,
            (data) => { 
                console.log(data); },
            (error) => { console.log(error) }
        );
    });
})

//================== ignore below ===================================

app.post('/analyzeImage3', (req, res) => {
    var form = new formidable.IncomingForm();
    form.parse(req, function (err, fields, files) {
        fs.readFile(files.imageFile.path, function(err, data) {
            microsofComputerVision.analyzeImage({
                "Ocp-Apim-Subscription-Key": subscriptionKey,
                "request-origin":"westcentralus",
                "content-type": "application/octet-stream",
                "body": data,
                "visual-features":"Tags, Categories, Description, Faces"
            }).then((result) => {
                  console.log(result)
              }).catch((err)=>{
                throw err
            })
        });
    });
})

app.post('/analyzeImage2', upload.any(), (req, res) => {
    const options = {
        uri: uriBase,
        qs: params,
        // body: '{"url": ' + '"' + files.imageFile.path + '"}',
        body: req.files[0].buffer,
        headers: {
            'Content-Type': 'application/json',
            'Ocp-Apim-Subscription-Key' : subscriptionKey
        }
    };
    request.post(options, (error, response, body) => {
        if (error) {
            console.log('Error: ', error);
            return;
        }
        let jsonResponse = JSON.stringify(JSON.parse(body), null, '  ');
        console.log('JSON Response\n');
        console.log(jsonResponse);
    });

    // request(options, (err, response, body) => {
    //     console.log('Request complete');
    //     if (err) console.log('Request err: ', err);
    //     console.log(body)
    // })        
})

app.post('/analyzeImage', (req, res) => {
    var form = new formidable.IncomingForm();

    form.parse(req, function (err, fields, files) {
        const options = {
            uri: uriBase,
            qs: params,
            // body: '{"url": ' + '"' + files.imageFile.path + '"}',
            body: files.imageFile,
            headers: {
                'Content-Type': 'application/json',
                'Ocp-Apim-Subscription-Key' : subscriptionKey
            }
        };
        request.post(options, (error, response, body) => {
            if (error) {
                console.log('Error: ', error);
                return;
            }
            let jsonResponse = JSON.stringify(JSON.parse(body), null, '  ');
            console.log('JSON Response\n');
            console.log(jsonResponse);
        });

        // res.send('ok!');
    });
    return;
})

app.listen(port, () => console.log(`Image Analyzer app listening on port ${port}!`))