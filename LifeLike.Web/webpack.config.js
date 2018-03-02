const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const bundleOutputDir = './wwwroot/dist';
const CheckerPlugin = require('awesome-typescript-loader');


module.exports = {
        stats: {modules: false},
        devtool: "inline-source-map",
        entry: {
            'main': './ClientApp/boot.tsx',
        },
        resolve: {extensions: ['.js', '.jsx', '.ts', '.tsx']},
        output: {
            path: path.join(__dirname, bundleOutputDir),
            filename: '[name].js',
            publicPath: 'dist/'
        },
        module: {
            rules: [
                {
                    test: /\.tsx?$/,
                    include: /ClientApp/,
                    loader: 'awesome-typescript-loader',
                    options: {
                        configFileName: 'tsconfig.json'
                    }
                },
                {
                    test: /\.ts?$/,
                    include: /ClientApp/,
                    loader: 'awesome-typescript-loader',
                    options: {
                        configFileName: 'tsconfig.json'
                    }
                },
                {
                    test: /\.less$/,
                    include: /ClientApp/,
                    use: [
                        {
                            loader: "css-loader",
                            options: {
                                outputPath: '/wwwroot/dist/',

                                sourceMap: true
                            }
                        }, {
                            loader: "less-loader",
                            options: {
                                outputPath: '/wwwroot/dist/',
                                sourceMap: true
                            }
                        }]
                },
                {
                    test: /\.(png|jpg|jpeg|gif|svg)$/,
                    use: 'url-loader?limit=25000'
                }
            ]
        }
};