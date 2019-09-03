const webpack = require("webpack");

module.exports = {
  plugins: [
    new webpack.DefinePlugin({
      "process.env": {
        ENV: JSON.stringify(envprocess.env.ENV),
        API: JSON.stringify(envprocess.env.API),
      },
    }),
  ],
};
