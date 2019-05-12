<template>
  <div class="hello">
    <h1>Deep Link Page</h1>
    <p>
      For a guide and recipes on how to configure / customize this project,<br>
      check out the
    </p>
    <h3>Links</h3>
    <ul>
      <li><router-link :to="{name: 'HelloWorld'}">Hello World Page</router-link></li>
      <li><router-link :to="{name: 'DeepLink'}">Client Side Deep Link Page</router-link></li>
      <li><a href="/deep/link" target="_blank">Client Side Deep Link Page</a></li>
      <li><a href="/api/fallback/test">API Test</a></li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'DeepLink'
}
</script>

