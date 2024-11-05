import axios from 'axios';

export const post = async (url, request) => {
    try {
        const response = await axios.post(url, request);
        if (response.status === 200) {
            return response.data;
        } else {
            throw new Error(`Server responded with status ${response.status}`);
        }
    } catch (error) {
        throw error;
    }
};