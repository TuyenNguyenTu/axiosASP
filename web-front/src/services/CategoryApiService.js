import axios from 'axios';

const client = axios.create({
    baseURL: 'https://localhost:44340/api/categories',
    json: true
});
export default {
    async excute(method, resource, data) {
        return client({
            method,
            url: resource,
            data,

        }).then(req => {
            return req.data;
        })
    },
    getAll() {
        return this.excute('get', '/');
    },
    create(data) {
        return this.excute('post', '/', data);
    },
    update(id, data) {
        return this.excute('put', `/${id}`, data);
    },
    delete(id) {
        try {
            return this.excute('delete', `/${id}`)
        } catch (err) {
            console.log(err)
        }
    }
}