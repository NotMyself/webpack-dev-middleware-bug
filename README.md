# Webpack Dev Middleware Bug Demo

This is a asp.net core application that uses the WebpackDevMiddleware to serve up the development version of a vue.js application. The app is setup so that the middleware is only used when running in Development mode.

There are two problems that have been identified with this setup:

1. You must add the aspnet-webpack and webpack-hot-middleware as dev dependcies to the vue.js app. When run using the WebpackDevMiddleware, you will get an stackoverflow error on updates. This is caused by vue.js already having HMR loaded when the WebpackDevMiddleware injects it. Adding this [vue.config.js](.src/client/vue.config.js), resolves this first issue.
2. Client side deep links throw a 404. It appears that the WebpackDevMiddleware will only serve up the SPA from the root directory. So the route `/` works but the route `/deep/link` does not. The middleware simply does not handle it and the server throws a 404.

## Getting Started

1. Clone the repository: `git clone https://github.com/NotMyself/webpack-dev-middleware-bug.git`.
1. Chage directory `cd webpack-dev-middleware-bug`.
1. Run the script `scripts/local-init` to install dependencies with the various package managers.
1. Run the script `scripts/local-start` to start the application in Development.
1. Optionally, run the script `scripts/local-production` to star the application in Production.

## The Bug

When running in either Development or Production, you will be presented with a series of links.

- Hello World Page: will use client side routing to link back to the root route.
- Client Side Deep Link Page 1: will use client side routing to link to `/deep/link`.
- Client Side Deep Link Page 2: will use server side routing to link to `/deep/link`.
- API Test: will use server side routing to display `/api/fallback/test` to demonstrate the server side routing is working.

When running in Development, **Client Side Deep Link Page 2** will throw a 404.

When running in Production, **Client Side Deep Link Page 2** will serve up the default spa fall back route and render the deep link as expected.

## Question?

This issue was reported on the AspNetCore repository, but sadly it was closed and suggested that I ask on StackOverflow.

- [Original App Issue](https://github.com/NotMyself/bivrost/issues/4)
- [AspNetCore Issue](https://github.com/aspnet/AspNetCore/issues/10002)
- [StackOverFlow Thread](https://stackoverflow.com/questions/56094371/client-side-deep-links-with-webpackdevmiddleware-404s)

How do I get client side deep links to work with Webpack Dev Middleware enabled for local development?

Is this a bug in the middleware or my configuration of it?
