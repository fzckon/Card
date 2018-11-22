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
var uglify = require('gulp-uglify');
var tsProject = ts.createProject('tsconfig.json');
var paths = {
    pages: ['./src/*.html', './src/*/*.html', './src/*/*/*.html'],
    js: ['./src/content/*/*.js', './src/content/*/*/*.js'],
    css: ['./src/content/*/*.css', './src/content/*/*/*.css'],
    img: ['./src/content/img/*.*', './src/content/img/*/*.*'],
    vendor: ['./src/vendor/*/*/*.min.js', './src/vendor/*/*/*/*.min.js', './src/vendor/*/*/*.min.css', './src/vendor/*/*/*/*.min.css'],
    hts: ["./src/*/*.ts", "./src/*/*/*.ts"],
    ts: ['./src/*.ts']
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
        .pipe(gulp.dest('dist'))
        .pipe(connect.reload());
});

gulp.task('vendor', function () {
    return gulp.src(paths.vendor)
        .pipe(gulp.dest('dist/vendor'));
});

gulp.task('ts', function () {
    tsProject.src()
        .pipe(tsProject())
        .pipe(buffer())
        .pipe(sourcemaps.init({ loadMaps: true }))
        //.pipe(uglify())
        .pipe(sourcemaps.write('./'))
        .pipe(gulp.dest("dist"))
        .pipe(connect.reload());
    // return gulp.src(paths.hts)
    //     .pipe(gulp.dest('dist'));
});

gulp.task('js', function () {
    return gulp.src(paths.js)
        .pipe(gulp.dest('dist/content'));
});

gulp.task('css', function () {
    return gulp.src(paths.css)
        .pipe(gulp.dest('dist/content'));
});

gulp.task('img', function () {
    return gulp.src(paths.img)
        .pipe(gulp.dest('dist/content/img'));
});
gulp.task('del-dist', function () { });
gulp.task('copy', ['html', 'css', 'js', 'img', 'vendor', 'ts']);

gulp.task('watch', function () {
    // body...
    gulp.watch(paths.pages, ['html']);
    gulp.watch(paths.ts, bundle);
    gulp.watch(paths.hts, ['ts']);
});

function bundle() {
    globby(paths.ts).then(function (entries) {
        //console.log(entries);

        var b = browserify({
            basedir: '.',
            debug: true,
            entries: entries,
            cache: {},
            packageCache: {}
        }).plugin(tsify);

        return b
            .transform('babelify', {
                presets: ['es2015'],
                extensions: ['.ts']
            })
            .bundle()
            .pipe(source('bundle.js'))
            .pipe(buffer())
            .pipe(sourcemaps.init({ loadMaps: true }))
            //.pipe(uglify())
            .pipe(sourcemaps.write('./'))
            .pipe(gulp.dest("dist"))
            .pipe(connect.reload());
    });
}

gulp.task('default', ['copy', 'webserver', 'watch'], bundle);
gulp.task('build', function () {
    gulp.src(paths.pages).pipe(gulp.dest('build'));
    gulp.src(paths.js).pipe(gulp.dest('./build/content'));
    gulp.src(paths.css).pipe(gulp.dest('./build/content'));
    gulp.src(paths.img).pipe(gulp.dest('./build/content/img'));
    tsProject.src()
        .pipe(tsProject())
        .pipe(buffer())
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(uglify())
        .pipe(sourcemaps.write('./'))
        .pipe(gulp.dest("build"));
    console.log('build');
    globby(paths.ts).then(function (entries) {
        var b = watchify(browserify({
            basedir: '.',
            debug: true,
            entries: entries,
            cache: {},
            packageCache: {}
        }).plugin(tsify));

        b.transform('babelify', {
            presets: ['es2015'],
            extensions: ['.ts']
        })
            .bundle()
            .pipe(source('bundle.js'))
            .pipe(buffer())
            .pipe(sourcemaps.init({ loadMaps: true }))
            .pipe(uglify())
            .pipe(sourcemaps.write('./'))
            .pipe(gulp.dest("build"));
        console.log('babelify');
        return;
    });
    console.log('end');
    return;
});

// function bundle() {
//     return watchedBrowserify
//         .transform('babelify', {
//             presets: ['es2015'],
//             extensions: ['.ts']
//         })
//         .bundle()
//         .pipe(source('bundle.js'))
//         .pipe(buffer())
//         .pipe(sourcemaps.init({ loadMaps: true }))
//         .pipe(sourcemaps.write('./'))
//         .pipe(gulp.dest("dist"));
// }
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
