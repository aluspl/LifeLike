const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const bundleOutputDir = './wwwroot/dist';
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');

module.exports = (env) => 
{
    const isDevBuild = !(env && env.prod);
    return [{
        stats: {modules: false},
        entry: ['./ClientApp/boot.tsx', './ClientApp/Styles/resume.scss' ]
        ,
        resolve: {extensions: ['.js', '.jsx', '.ts', '.tsx']},
        output: {
            path: path.join(__dirname, bundleOutputDir),
            filename: 'main.js',
            publicPath: 'dist/'
        },
        module: {
            rules: [
                {
                    test: /\.tsx?$/,
                    include: /ClientApp/,
                    loader: 'ts-loader'
                },
                { // sass / scss loader for webpack
                    test: /\.(sass|scss)$/,
                    loader: ExtractTextPlugin.extract(['css-loader', 'sass-loader'])
                },
                
                {
                    test: /\.css$/,
                    include: /ClientApp/,
                    use: isDevBuild ?
                        ['style-loader', 'css-loader'] :
                        ExtractTextPlugin.extract({use: 'css-loader?minimize'})
                },
                {test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000'}
            ]
        },
        plugins: [
            new UglifyJsPlugin(),
            new ExtractTextPlugin({ // define where to save the file
                filename: '[name].bundle.css',
                allChunks: true
            }),
            new CheckerPlugin()
        ]
    }];
}
