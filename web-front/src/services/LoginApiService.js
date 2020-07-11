import axios from 'axios';

const client = axios.create({
    baseURL: "https://localhost:44340/api/accounts",
    json: true,
    headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.token
    }
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
    login(data) {
        try {
            return this.excute('post', '', data)
        } catch (err) {
            console.log(err)
        }
    }
}