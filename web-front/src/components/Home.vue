<template>
  <div class="container-fluid mt-4">
    <h1 class="h1">Home Component</h1>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-row>
      <b-col>
        <table class="table table-striped">
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th>Description</th>
              <th>Date Time</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="record in records" :key="record.id">
              <td>{{ record.id }}</td>
              <td>{{ record.name }}</td>
              <td>{{ record.description }}</td>
              <td>{{ format_date(record.createDate) }}</td>
              <td class="text-right">
                <a href="#" @click.prevent="updateCategoryRecord(record)">Edit</a>
                -
                <a href="#" @click.prevent="deleteCategory(record.id)">Delete</a>
              </td>
            </tr>
          </tbody>
        </table>
      </b-col>
      <b-col lg="3">
        <button class="btn btn-success" @click="showForm">Show Form</button>
        <b-card
          :title="model.id ? 'Edit With ID#' + model.id : 'New Record'"
          v-if="isShowForm"
          @reset="onReset"
        >
          <form @submit.prevent="createCategoryRecord">
            <b-form-group label="Name">
              <b-form-input type="text" v-model="model.name" aria-required="Nhập thông tin"></b-form-input>
            </b-form-group>
            <b-form-group label="Description">
              <b-form-input v-model="model.description" type="text" aria-required="Nhập thông tin"></b-form-input>
            </b-form-group>
            <b-form-group label="Ngày tạo">
              <b-form-input v-model="model.createDate" id="createdTime" type="date"></b-form-input>
            </b-form-group>
            <div>
              <b-btn type="submit" variant="success">Save Record</b-btn>
              <b-button type="reset" variant="danger">Reset</b-button>
            </div>
          </form>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import moment from "moment";
import api from "../services/CategoryApiService";
export default {
  name: "home-component",
  data() {
    return {
      loading: false,
      records: [],
      model: {},
      isShowForm: false,
      myDate: new Date()
    };
  },
  async created() {
    this.getAll();
  },
  methods: {
    async getAll() {
      this.loading = true;
      try {
        this.records = await api.getAll();
      } finally {
        this.loading = false;
      }
    },
    async updateCategoryRecord(category) {
      this.isShowForm = true;

      this.model = Object.assign({}, category);
    },
    async createCategoryRecord() {
      const isUpdate = this.model.id;
      if (isUpdate) {
        console.log(this.model);
        await api.update(this.model.id, this.model);
      } else {
        await api.create(this.model);
      }

      this.model = {};
      await this.getAll();
    },
    async deleteCategory(id) {
      if (confirm("Bạn có chắc chắn muốn xóa bản ghi")) {
        if (this.model.id === id) {
          this.model = {};
        }
        await api.delete(id);
        await this.getAll();
      }
    },
    format_date(value) {
      if (value) {
        return moment(String(value)).format("yyyy-MM-DD");
      }
    },
    showForm() {
      this.isShowForm = !this.isShowForm;
    },
    onReset() {
      this.model = {};
      this.isShowForm = false;
    }
  },
  computed: {
    getCreateDate() {
      return this.format_date(this.model.createDate);
    }
  }
};
</script>

<style></style>
