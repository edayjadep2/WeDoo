# Custom Vision API

Simple interface for customvision.ai (great way to start with your image recognition project - thank you to the guys at Microsoft cognitive services!

## Example usage

```javascript
const cv = require('customvision-api');
const filePath = 'img/test.jpg';
const config = {
    "predictionEndpoint": "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.0/Prediction/11111111-1111-1111-1111-111111111111/image",
    "predictionKey": "11110000111100001111000011110000"
};
cv.sendImage(
    filePath,
    config,
    (data) => { console.log(data); },
    (error) => { console.log(error) }
);
```

