var gulp = require('gulp');
var connect = require('gulp-connect');
var ts = require('gulp-typescript');
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var tsify = require('tsify');
var watchify = require("watchify");
var sourcemaps = require('gulp-sourcemaps');
var buffer = require('vinyl-buffer');
var globby = require('globby');
var tsProject = ts.createProject('tsconfig.json');
var paths = {
    pages: ['./*.html', './*/*.html', '!./dist/*'],
    js: ['./js/*'],
    css: ['./css/*'],
    img: ['./img/*'],
    ts: ['./*.ts', './*/*.ts', '!./dist/*']
};

gulp.task('webserver', function () {
    connect.server({
        port: 9000,
        root: ['./dist/'],
        livereload: true
    });

});

gulp.task('html', function () {
    return gulp.src(paths.pages)
        .pipe(gulp.dest('dist'));
});

gulp.task('ts', function () {
    return gulp.src(paths.ts)
        .pipe(gulp.dest('dist'));
});

gulp.task('js', function () {
    return gulp.src(paths.js)
        .pipe(gulp.dest('dist'));
});

gulp.task('css', function () {
    return gulp.src(paths.css)
        .pipe(gulp.dest('dist'));
});

gulp.task('img', function () {
    return gulp.src(paths.img)
        .pipe(gulp.dest('dist'));
});

gulp.task('copy', ['html', 'css', 'js', 'img']);

gulp.task('watch', function () {
    // body...
    gulp.watch(paths.pages, ['html']).pipe(connect.reload());
    gulp.watch(paths.ts, bundle).pipe(connect.reload());
});

var watchedBrowserify = watchify(
    browserify({
        basedir: '.',
        debug: true,
        entries: '',
        cache: {},
        packageCache: {}
    }).plugin(tsify)
);

var watchedBrowserify1 = globby(paths.ts).then(function (entries) {
    var b = watchify(browserify({
        basedir: '.',
        debug: true,
        entries: entries,
        cache: {},
        packageCache: {}
    }).plugin(tsify));

    return b;
});

(async () => {
    const a = await globby(paths.ts);

    console.log(a);
    //=> ['unicorn', 'rainbow']
})();

function bundle1() {
    globby(paths.ts).then(function (entries) {

        var b = watchify(browserify({
            basedir: '.',
            debug: true,
            entries: entries,
            cache: {},
            packageCache: {}
        }).plugin(tsify));

        return b
            .transform('babelify', {
                presets: ['es2015'],
                extensions: ['.ts']
            })
            .bundle()
            .pipe(source('bundle.js'))
            .pipe(buffer())
            .pipe(sourcemaps.init({ loadMaps: true }))
            .pipe(sourcemaps.write('./'))
            .pipe(gulp.dest("dist"));
    });


}

function bundle() {
    return watchedBrowserify
        .transform('babelify', {
            presets: ['es2015'],
            extensions: ['.ts']
        })
        .bundle()
        .pipe(source('bundle.js'))
        .pipe(buffer())
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(sourcemaps.write('./'))
        .pipe(gulp.dest("dist"));
}
gulp.task('default', ['copy', 'webserver'], bundle1);

// gulp.task('default', ['copy', 'webserver'], function () {
//     return browserify({
//         basedir: '.',
//         debug: true,
//         entries: ['./index.ts'],
//         cache: {},
//         packageCache: {}
//     })
//         .plugin(tsify)
//         .transform('babelify', {
//             presets: ['es2015'],
//             extensions: ['.ts']
//         })
//         .bundle()
//         .pipe(source('bundle.js'))
//         .pipe(buffer())
//         .pipe(sourcemaps.init({ loadMaps: true }))
//         .pipe(sourcemaps.write('./'))
//         .pipe(gulp.dest('dist'));
// });

// const watchedBrowserify = watchify(browserify({
//     basedir: '.',
//     debug: true,
//     entries: ['src/main.ts'],
//     cache: {},
//     packageCache: {}
//   }).plugin(tsify));

//   gulp.task("copy-html", function () {
//     return gulp.src(paths.pages)
//       .pipe(gulp.dest("dist"));
//   })

//   function browserifyBundle() {
//     return watchedBrowserify
//       .bundle()
//       .pipe(source('bundle.js'))
//       .pipe(gulp.dest("dist"));
//   }

//   gulp.task("browserify", function() {
//     return browserifyBundle();
//   })

//   gulp.task("default", gulp.series('copy-html', 'browserify'));
//   watchedBrowserify.on("update", browserifyBundle);
//   watchedBrowserify.on("log", gutil.log);
