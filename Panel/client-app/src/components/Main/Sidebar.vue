<template>
    <div class="hidden">
        <vs-sidebar absolute
                    hover-expand
                    reduce
                    open>
            <template #logo>
                <!-- ...img logo -->
            </template>
            <vs-sidebar-item id="home">
                <template #icon>
                    <Icon name="home" />
                </template>
                Home
            </vs-sidebar-item>

            <vs-sidebar-group>
                <template #header>
                    <vs-sidebar-item arrow>
                        <template #icon>
                            <Icon name="mobile" />
                        </template>
                        My Applications
                    </vs-sidebar-item>
                </template>

                <vs-sidebar-item>
                    <template #icon>
                        <Icon name="users" />
                    </template>
                    Users
                </vs-sidebar-item>
                <vs-sidebar-item >
                    <template #icon>
                        <Icon name="bell" />
                    </template>
                    Notifications
                </vs-sidebar-item>
            </vs-sidebar-group>

            <vs-sidebar-group>
                <template #header>
                    <vs-sidebar-item arrow>
                        <template #icon>
                            <Icon name="user-circle" />
                        </template>
                        Account
                    </vs-sidebar-item>
                </template>

                <vs-sidebar-item arrow>
                    <template #icon>
                        <Icon name="reply" />
                    </template>
                    Login
                </vs-sidebar-item>
                <vs-sidebar-item arrow>
                    <template #icon>
                        <Icon name="share" />
                    </template>
                   sign out
                </vs-sidebar-item>
            </vs-sidebar-group>

            <template #footer>
                <vs-row justify="space-between">

                    <vs-avatar>
                        <img src="../../assets/logo.png" alt="">
                    </vs-avatar>
                </vs-row>
            </template>
        </vs-sidebar>
    </div>
</template>
<script>
    import Icon from 'vue-awesome/components/Icon'
    export default {
        name: 'Sidebar',
        components: {
            Icon
        }
    }
</script>