require('dotenv').config();

const webpack = require('webpack');

module.exports = {
  plugins: [
    new webpack.DefinePlugin({
      ENV: {
        ENV: JSON.stringify(process.env.ENV),
        API: JSON.stringify(process.env.API),
      }
    })
  ]
};