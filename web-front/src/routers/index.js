import Router from 'vue-router';
import Vue from 'vue';

import Home from '@/components/Home';
import Contact from '@/components/Contact';
import Login from '@/components/Login';
Vue.use(Router);

let router = new Router({
    mode: 'history',
    routes: [{
            path: '/',
            name: 'Login',
            component: Login
        },
        {
            path: '/list-data',
            name: 'Home',
            component: (Home)
        }, {
            path: '/hello-world',
            name: 'Hello',
            component: () =>
                import ('../components/HelloWorld')
        },
        {
            path: '/contact',
            name: 'Contact',
            component: Contact
        }
    ]
})
export default router;