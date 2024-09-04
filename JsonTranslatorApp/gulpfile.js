const {src, dest, watch, series} = require('gulp')
const sass = require('gulp-sass')(require('sass'))
const purgeCss = require('gulp-purgecss')

const root = "./wwwroot/css";

const bootstrap = "./node_modules/bootstrap/dist/css/bootstrap.min.css";
const bootstrapIcons = "./node_modules/bootstrap-icons/font/bootstrap-icons.min.css";

async function buildStyles() {
    return await src('Sass/**/*.scss')
        .pipe(sass({outputStyle: 'compressed'}))
        .pipe(purgeCss({ content: ['**/*.cshtml', '**/*.html', '**/*.razor'] })) // WARNING: only used CSS will be rendered
        .pipe(dest('wwwroot/css'))

}

async function watchTask() {
    await watch(['Sass/**/*.scss', '*.html'], buildStyles)
}

async function bootstrapTask() {
    src([bootstrap]).pipe(dest(root+'/bootstrap/'));
}

async function bootstrapIconsTask() {
    src([bootstrapIcons]).pipe(dest(root+'/bootstrap-icons/'));
}



exports.default = series(buildStyles, watchTask, bootstrapTask, bootstrapIconsTask)