<template>
    <div>
        <sidebar />
        <div class="main-layout">
            <slot>

            </slot>
        </div>
    </div>
</template>

<script>
    import sidebar from '../components/Main/Sidebar.vue'

    export default {
        name: 'MainLayout',
        components: {
            sidebar
        }
    }
</script>

<style>
@import '../assets/styles/main.css';
</style>