var path = require("path");
const HtmlWebpackPlugin = require('html-webpack-plugin')

var commonPlugins = [
    new HtmlWebpackPlugin({
        filename: 'index.html',
        template: './index.html',
    })
];

module.exports = {
    mode: "development",
    entry: {
        app: ["./src/Life.Client.fsproj"],
        style: ["./scss/main.scss"]
    },
    output: {
        path: path.join(__dirname, "./public"),
        filename: "[name].bundle.js",
    },
    devServer: {
        contentBase: "./public",
        port: 8087,
    },
    plugins: commonPlugins,
    module: {
        rules: [{
            test: /\.fs(x|proj)?$/,
            use: "fable-loader"
        },{
            test: /\.(sass|scss|css)$/,
            use: [
                'style-loader',
                'css-loader',
                'sass-loader',
            ]
        }, {
            test: /\.(png|woff|woff2|eot|ttf|svg)$/,
            loader: 'url-loader?limit=100000'
        }]
    }
}