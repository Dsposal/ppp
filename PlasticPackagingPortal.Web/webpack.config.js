/* eslint-disable no-undef */

const path = require("path");
const webpack = require("webpack");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    mode: 'production',
    devtool: 'source-map',
    target: ['web'],
    entry: {
        "css/main": "./src/sass/pixel.scss",
        "js/main": './src/js/pixel.js',
    },
    output: {
        path: path.resolve(__dirname, ".", "wwwroot", "dist"),
        //chunkFilename: "js/chunks/[name].js",
        filename: "[name].js",
        //library: {
        //    type: "global"
        //},
        clean: true,
    },
    //optimization: {
    //    //chunkIds: "deterministic",
    //    usedExports: true,
    //    runtimeChunk: { name: "js/runtime" },
    //    splitChunks: {
    //        //chunks: "all",
    //        //maxInitialRequests: Infinity,
    //        //minSize: 0,
    //        cacheGroups: {
    //            vendor: {
    //                test: /[\\/]node_modules[\\/]/,
    //                name: "js/vendors",
    //                chunks: "all",
    //            },
    //            commons: {
    //                test: /[\\/]src[\\/]js[\\/]utils[\\/]/,
    //                name: "js/common/utils",
    //                chunks: "initial",
    //                minChunks: 2,
    //            }
    //        },
    //    },
    //},
      module: {
        rules: [
            {
                test: /\.(css)$/,
                use: [MiniCssExtractPlugin.loader, "css-loader"]
            },
            {
                test: /\.s[ac]ss$/,
                use: [MiniCssExtractPlugin.loader, "css-loader", "sass-loader"]
            },
            {
                test: /\.(js)$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader",
                    options: {
                        babelrc: false,
                        // eslint-disable-next-line no-undef
                        configFile: path.resolve(__dirname, "babel.config.js"),
                        compact: false,
                        cacheDirectory: true,
                        sourceMaps: true
                    },
                },
            },
            {
                test: /\.(jpe?g|svg|png|gif|ico|eot|ttf|woff2?)(\?v=\d+\.\d+\.\d+)?$/i,
                type: "asset/resource",
                generator: {
                    filename: "assets/[name][ext][query]"
                }
            },
        ]
    },
    resolve: {
        extensions: [
            "...", ".css", ".scss", ".sass"
        ],
        alias: {
        },
        fallback: {
            fs: false,
        }
    },
    plugins: [
        new MiniCssExtractPlugin(),
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery',
        }),
    ]
};