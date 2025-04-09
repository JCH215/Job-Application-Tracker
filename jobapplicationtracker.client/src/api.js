import axios from "axios";

const API_URL = "https://localhost:7198/api/jobApplications";

export const getAllApplications = () => axios.get(API_URL);    
export const getApplicationById = (id) => axios.get(`${API_URL}/${id}`);
export const updateApplication = (id, data) => axios.put(`${API_URL}/${id}`, data);
export const createApplication = (data) => axios.post(API_URL, data);
export const getPagedApplications = (pageSize, pageNo) => axios.get(`${API_URL}/${pageSize}/${pageNo}`);    