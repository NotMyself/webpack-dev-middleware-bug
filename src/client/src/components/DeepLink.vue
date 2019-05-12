<template>
  <div class="hello">
    <h1>Deep Link Page</h1>
    <p>
      For a guide and recipes on how to configure / customize this project,<br>
      check out the
    </p>
    <h3>Links</h3>
    <ul>
      <li>
        <em>
          <router-link :to="{name: 'HelloWorld'}">
          Hello World Page
          </router-link>
          </em>
          Uses client side routing to link back to the root route
      </li>
      <li>
        <em>
          <router-link :to="{name: 'DeepLink'}">
            Client Side Deep Link Page 1
          </router-link>
        </em>
         Uses client side routing to link to /deep/link
      </li>
      <li>
        <em>
          <a href="/deep/link" target="_blank">
          Client Side Deep Link Page 2
          </a>
        </em>
         Uses traditional anchor tag to open /deep/link in a new tab.
         This fails when running in Development, but works when running
          in Production.
      </li>
      <li>
        <em>
          <a href="/api/fallback/test">
            API Test
          </a>
        </em>
        Uses traditional anchor tag to open /api/fallback/test to show
        that api routing works.
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'DeepLink'
}
</script>

