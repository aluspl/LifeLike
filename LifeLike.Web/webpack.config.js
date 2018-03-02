const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const bundleOutputDir = './wwwroot/dist';
const CheckerPlugin = require('awesome-typescript-loader');
const extractLESS = new ExtractTextPlugin('Styles/[name]-two.css');


module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    
    return [{
        stats: { modules: false },
        devtool: "inline-source-map",
        entry: { 
            'main': './ClientApp/boot.tsx', 
        },
        resolve: { extensions: ['.js', '.jsx', '.ts', '.tsx'] },
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
                    loader: 'awesome-typescript-loader'
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
                { test: /\.css$/,   
                    include: /ClientApp/, 
                    use: isDevBuild ? 
                    ['style-loader', 'css-loader'] : 
                    ExtractTextPlugin.extract({ use: 'css-loader?minimize' }) },
                { 
                    test: /\.(png|jpg|jpeg|gif|svg)$/, 
                    use: 'url-loader?limit=25000' 
                }
            ]
        },
        plugins: [
        ]
    }];
}