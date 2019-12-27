const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = {
    entry: './wwwroot/js/src/site.js',
    output: {
        filename: 'main.js',
        path: path.resolve(__dirname, './wwwroot/js/dist')
    },
    module: {
        rules: [
            {
                test: /\.css$/,
                use: [
                    'vue-style-loader',
                    'css-loader'
                ]
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    hotReload: true
                }
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                exclude: /node_modules/
            },
            {
                test: /\.scss$/,
                loader: "sass-loader"
            }
        ]
    },
    resolve: {
        alias: {
            'vue$': 'vue/dist/vue.esm.js',
            'Components': path.resolve(__dirname, 'src/components')
        },
        extensions: ['*', '.js', '.vue', '.json']
    },
    performance: {
        hints: false
    },
    devtool: '#eval-source-map',
    plugins: [
        // make sure to include the plugin for the magic
        new VueLoaderPlugin()
    ]
};
