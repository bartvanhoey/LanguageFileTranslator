const {src, dest, watch, series} = require('gulp')
const sass = require('gulp-sass')(require('sass'))
const purgeCss = require('gulp-purgecss')

const rootCss = "./wwwroot/css";
const root = "./wwwroot";

const bootstrap = "./node_modules/bootstrap/dist/css/bootstrap.min.css";
const bootstrapIcons = "./node_modules/bootstrap-icons/font/bootstrap-icons.min.css";
const bootstrapFontsWoff = "./node_modules/bootstrap-icons/font/fonts/bootstrap-icons.woff";
const bootstrapFontsWoff2 = "./node_modules/bootstrap-icons/font/fonts/bootstrap-icons.woff2";

async function buildStyles() {
    return await src('Sass/**/*.scss')
        .pipe(sass({outputStyle: 'compressed'}))
        // .pipe(purgeCss({ content: ['**/*.cshtml', '**/*.html', '**/*.razor'] })) // WARNING: only used CSS will be rendered
        .pipe(dest('wwwroot/css'))

}

async function watchTask() {
    await watch(['Sass/**/*.scss', '*.html'], buildStyles)
}

async function bootstrapTask() {
    src([bootstrap]).pipe(dest(rootCss+'/bootstrap/'));
}

async function bootstrapIconsTask() {
    src([bootstrapIcons]).pipe(dest(rootCss+'/bootstrap-icons/'));
}

async function bootstrapFontsWoffTask() {
    src([bootstrapFontsWoff], { encoding: false }).pipe(dest(rootCss+'/bootstrap-icons/fonts/'));
}

async function bootstrapFontsWoff2Task() {
    src([bootstrapFontsWoff2], { encoding: false }).pipe(dest(rootCss+'/bootstrap-icons/fonts/'));
}



exports.default = series(buildStyles, watchTask, bootstrapTask, bootstrapIconsTask, bootstrapFontsWoffTask, bootstrapFontsWoff2Task)