git config --global url."https://".insteadOf git://

npm cache clean
npm install

.\node_modules\.bin\bower.cmd cache clean
.\node_modules\.bin\bower.cmd install

#.\node_modules\.bin\gulp.cmd build

.\node_modules\.bin\rimraf.cmd .\node_modules\