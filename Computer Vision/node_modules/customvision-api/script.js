const fs = require('fs');
const request = require('request');

/**
 * Sends an image to customvision.ai and returns analysis result
 * @param {string} filepath - the path to the image to send
 * @param {object} config - config object e.g. {"predictionEndpoint": "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.0/Prediction/11111111-1111-1111-1111-111111111111/image", "predictionKey": "11110000111100001111000011110000"}
 * @param {function} successCallback - method to be called in case of success (gets data as single parameter)
 * @param {function} [errorCallback] - method to be called in case of error (gets error data as first and data as second parameter)
 */
function sendImage(filepath, config, successCallback, errorCallback = null) {

    let formData = {
        file: fs.createReadStream(filepath),
    };
    let options = {
        url: config.predictionEndpoint,
        headers: {
            'Prediction-Key': config.predictionKey,
            'Content-Type': 'multipart/form-data'
        },
        formData: formData
    };

    request.post(options, (err, httpResponse, body) => {
        if (err && errorCallback) {
            errorCallback(err, body);
        }
        else if (err) {
            successCallback(null);
        }
        else {
            successCallback(JSON.parse(body));
        }
    });
}

module.exports = { sendImage: sendImage };