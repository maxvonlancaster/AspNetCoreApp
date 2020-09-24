const path = require('path');
//const no_dist = (env && env.dist === "false");

module.exports = env => {
    const no_dist = (env && env.dist === "false");
    return {
        context: __dirname,
        entry: {
            app: './index.js',
            slideApp: './app.js'
        },
        output: {
            path: __dirname + "/dist",
            filename: '[name]bundle.js'
            //path: path.resolve(__dirname, 'dist')
        },
        resolve: {
            extensions: ['.js', '.jsx', '.css']
        },
        watch: true,
        module: {
            rules: [{
                test: /\.(js|jsx)$/, // include .js files
                enforce: "pre", // preload the jshint loader
                exclude: /node_modules/, // exclude any and all files in the node_modules folder
                use: [{
                    loader: "babel-loader",
                    // more options in the optional jshint object
                    options: {  // :arrow_left: formally jshint property
                        presets: ['babel-preset-env', 'babel-preset-react', 'react'],
                        plugins: ["transform-class-properties", "babel-plugin-transform-object-rest-spread"]
                    }
                }]
            },
            { test: /\.css$/, use: [{ loader: "css-loader" }] }]
        },
    }
};