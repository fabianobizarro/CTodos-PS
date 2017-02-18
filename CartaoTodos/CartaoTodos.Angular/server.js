const express = require('express');

var app = express();

app.use(express.static('wwwroot'));

app.listen(8000, function(){
    console.log('Aplicação rodando em http://localhost:8000')
});