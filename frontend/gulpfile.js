// Generated on 2016-08-09 using generator-angular 0.15.1
'use strict';

var gulp = require('gulp');
var gutil = require('gulp-util');
var $ = require('gulp-load-plugins')();
var openURL = require('open');
var lazypipe = require('lazypipe');
var rimraf = require('rimraf');
var wiredep = require('wiredep').stream;
var runSequence = require('run-sequence');
var inject = require('gulp-inject');
var replace = require('gulp-replace');
var concat = require('gulp-concat');
var mainBowerFiles = require('main-bower-files');

var yeoman = {
  app: require('./bower.json').appPath || 'app',
  dist: 'dist'
};

var paths = {
  scripts: [yeoman.app + '/assets/**/*.js'],
  styles: [yeoman.app + '/assets/css/**/*.css'],
  test: ['test/spec/**/*.js'],
  testRequire: [
    yeoman.app + '/bower_components/angular/angular.js',
    yeoman.app + '/bower_components/angular-mocks/angular-mocks.js',
    yeoman.app + '/bower_components/angular-resource/angular-resource.js',
    yeoman.app + '/bower_components/angular-cookies/angular-cookies.js',
    yeoman.app + '/bower_components/angular-sanitize/angular-sanitize.js',
    yeoman.app + '/bower_components/angular-ui-router/release/angular-ui-router.js',
    'test/mock/**/*.js',
    'test/spec/**/*.js'
  ],
  karma: 'karma.conf.js',
  views: {
    main: yeoman.app + '/index.html',
    files: [yeoman.app + '/views/**/*.html']
  }
};

////////////////////////
// Reusable pipelines //
////////////////////////

var lintScripts = lazypipe()
  .pipe($.jshint, '.jshintrc')
  .pipe($.jshint.reporter, 'jshint-stylish');

var styles = lazypipe()
  .pipe($.autoprefixer, 'last 1 version')
  .pipe(gulp.dest, '.tmp/styles');

///////////
// Tasks //
///////////

gulp.task('styles', function () {
  return gulp.src(paths.styles)
    .pipe(styles());
});

gulp.task('lint:scripts', function () {
  return gulp.src(paths.scripts)
    .pipe(lintScripts());
});

gulp.task('clean:tmp', function (cb) {
  rimraf('./.tmp', cb);
});

gulp.task('start:client', ['start:server', 'styles', 'inject'], function () {
  openURL('http://localhost:9000/app');
});

gulp.task('start:server', function() {
  $.connect.server({
    root: ['../frontend', '.tmp'],
    livereload: true,
    // Change this to '0.0.0.0' to access the server from outside.
    port: 9000
  });
});

gulp.task('start:server:test', function() {
  $.connect.server({
    root: ['test', yeoman.app, '.tmp'],
    livereload: true,
    port: 9001
  });
});

gulp.task('watch', function () {
  $.watch(paths.styles)
    .pipe($.plumber())
    .pipe(styles())
    .pipe($.connect.reload());

  $.watch(paths.views.files)
    .pipe($.plumber())
    .pipe($.connect.reload());

  $.watch(paths.scripts)
    .pipe($.plumber())
    .pipe(lintScripts())
    .pipe($.connect.reload());

  $.watch(paths.test)
    .pipe($.plumber())
    .pipe(lintScripts());

  gulp.watch('bower.json', ['bower']);
});

gulp.task('serve', function (cb) {
  runSequence('clean:tmp',
    ['lint:scripts'],
    ['start:client'],
    'watch', cb);
});

gulp.task('serve:prod', function() {
  $.connect.server({
    root: [yeoman.dist],
    livereload: true,
    port: 9001
  });
});

gulp.task('test', ['start:server:test'], function () {
  var testToFiles = paths.testRequire.concat(paths.scripts, paths.test);
  return gulp.src(testToFiles)
    .pipe($.karma({
      configFile: paths.karma,
      action: 'watch'
    }));
});

// inject bower components
gulp.task('bower', function () {
  return gulp.src(paths.views.main)
    .pipe(wiredep({
      directory: 'bower_components',
      ignorePath: '..',
      devDependencies: true
    }))
  .pipe(gulp.dest(yeoman.app));
});

///////////
// Build //
///////////

gulp.task('clean:dist', function (cb) {
  rimraf('./dist', cb);
});

gulp.task('client:build', ['html', 'component', 'componentjs', 'shared', 'sharedjs','mainjs', 'bowerjs','styles', 'copy:styles','copy:scripts'], function () {

  /*return gulp.src(paths.views.main)
    .pipe($.useref())
    .pipe(jsFilter)
    .pipe($.ngAnnotate())
    .pipe($.uglify())
    .pipe(jsFilter.restore())
    .pipe(cssFilter)
    .pipe($.minifyCss({cache: true}))
    .pipe(cssFilter.restore())
    .pipe($.rev())
    .pipe($.revReplace())
    .pipe(gulp.dest(yeoman.dist));*/
    runSequence(['inject:prod'])
});

gulp.task('html', function () {
  return gulp.src(yeoman.app + '/*.html')
    .pipe(gulp.dest(yeoman.dist));
});

gulp.task('component', function () {
  return gulp.src(yeoman.app + '/app/component/**/*.html')
    .pipe(gulp.dest(yeoman.dist + '/app/component'));
});

gulp.task('shared', function () {
  return gulp.src(yeoman.app + '/app/shared/**/*.html')
    .pipe(gulp.dest(yeoman.dist + '/app/shared'));
});

gulp.task('componentjs', function () {
  return gulp.src(yeoman.app + '/app/component/**/*.js')
    .pipe(gulp.dest(yeoman.dist + '/app/component'));
});

gulp.task('sharedjs', function () {
  return gulp.src(yeoman.app + '/app/shared/**/*.js')
    .pipe(gulp.dest(yeoman.dist + '/app/shared'));
});

gulp.task('mainjs', function () {
  return gulp.src(yeoman.app + '/app/*.js')
    .pipe(concat('main.js'))
    .pipe(gulp.dest(yeoman.dist + '/app'));
});

gulp.task('copy:scripts', function () {
  var jsFile = [yeoman.app + '/assets/usedjs/**/*.js'];
  return gulp.src(jsFile)
    .pipe($.uglify())
    .pipe(gulp.dest(yeoman.dist + '/js'));
});

gulp.task('copy:styles', function () {
  var cssFile = [yeoman.app + '/assets/css/**/*.css'];
  return gulp.src(cssFile)
    .pipe($.minifyCss({cache: true}))
    .pipe(gulp.dest(yeoman.dist + '/assets/css'));
});

gulp.task('bowerjs', function () {
  gutil.log(mainBowerFiles());
  return gulp.src(mainBowerFiles())
    .pipe(concat('vendor.js'))
    .pipe($.uglify())
    .pipe(gulp.dest(yeoman.dist + '/vendor'));
});

gulp.task('images', function () {
  return gulp.src(yeoman.app + '/assets/images/*')
    .pipe($.cache($.imagemin({
        optimizationLevel: 5,
        progressive: true,
        interlaced: true
    })))
    .pipe(gulp.dest(yeoman.dist + '/assets/images'));
});

gulp.task('copy:extras', function () {
  return gulp.src(yeoman.app + '/assets/avatars/*')
    .pipe(gulp.dest(yeoman.dist + '/assets/avatars'));
});

gulp.task('copy:fonts', function () {
  return gulp.src(yeoman.app + '/assets/fonts/*')
    .pipe(gulp.dest(yeoman.dist + '/assets/fonts'));
});

gulp.task('inject', function(){
  var target = gulp.src('app/index.html');

  var sources = gulp.src(['app/app/component/**/*.js', 'app/app/shared/**/*.js'], {read: false});

  return target.pipe(inject(sources))
    .pipe(gulp.dest('app/'));
});

gulp.task('inject:prod', function(){
  var sources = gulp.src([yeoman.dist + '/js/jquery.js', yeoman.dist + '/vendor/*.js', yeoman.dist + '/js/**/*.js', yeoman.dist + '/app/*.js', yeoman.dist + '/app/**/*.js'], {read: false});

  return gulp.src(yeoman.dist + '/index.html')
    .pipe($.useref())
    .pipe(inject(sources))
    .pipe(replace('/dist', ''))
    //.pipe(replace('assets', ''))
    .pipe(gulp.dest(yeoman.dist));
});

gulp.task('build', ['clean:dist'], function () {
  runSequence(['images', 'copy:extras', 'copy:fonts', 'client:build']);
});

gulp.task('default', ['build']);
