<template>
    <div class="loginfo-component">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="post" class="content">
            <table>
                <thead>
                    <tr>
                        <th>Client IP</th>
                        <th>FQDN</th>
                        <th>Calls per client IP</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="entry, index in post.logEntries" v-bind:key="index">
                        <td>{{ entry.clientIp }}</td>
                        <td>{{ entry.fqdnOfClientIp }}</td>
                        <td>{{ entry.totalCallsPerClientIp }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import axios from 'axios';


    type LogInfoViewModel = {
        logEntries: LogEntry[],
    }

    type LogEntry = {
        clientIp: string,
        fqdnOfClientIp: string,
        totalCallsPerClientIp: number
    }

    interface Data {
        loading: boolean,
        post: null | LogInfoViewModel
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData(): void {
                this.post = null;
                this.loading = true;
                
                axios.get('https://localhost:44340/api/LogInfo')
                    .then((response) => {
                        this.post = response.data as LogInfoViewModel;
                    })
                    .catch((error) => {
                        // eslint-disable-next-line no-console
                        console.log('Error caught calling the api:');
                        // eslint-disable-next-line no-console
                        console.log(error);
                    })
                    .then(() => {
                        this.loading = false;
                    });
            }
        },
    });
</script>

<style scoped>
th {
    font-weight: bold;
}
tr:nth-child(even) {
    background: #F2F2F2;
}

tr:nth-child(odd) {
    background: #FFF;
}

th, td {
    padding-left: .5rem;
    padding-right: .5rem;
}

table {
    margin-left: auto;
    margin-right: auto;
}
</style>