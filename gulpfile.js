//ImportHere
var gulp = require("gulp");
module.exports = gulp;
const fs = require('fs');
const cleanCSS = require('gulp-clean-css');
const rename = require('gulp-rename');
const uglify = require('gulp-uglify');

// Minify JS files in wwwroot/js/
gulp.task('minify-js', function () {
    return gulp.src('webapp/Stay-Reservation/wwwroot/scripts/*.js') 
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('webapp/Stay-Reservation/wwwroot/scripts/min'));   
});

// CSS Minify Task
gulp.task('minify-css', function () {
    return gulp.src(['webapp/Stay-Reservation/wwwroot/css/**/*.css', '!webapp/Stay-Reservation/wwwroot/css/**/*.min.css']) 
        .pipe(cleanCSS({ compatibility: 'ie8' }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('webapp/Stay-Reservation/wwwroot/css/'));
});

//replace placeholder with actual require statement
gulp.task('dynamic-import', async function(){
    var gulpfile = await fs.readFileSync('./gulpfile.js', 'utf-8');
    gulpfile = gulpfile.replace('//ImportHere', 'require("@syncfusion/ej2-staging");');
    await fs.writeFileSync('./gulpfile.js', gulpfile);
});
