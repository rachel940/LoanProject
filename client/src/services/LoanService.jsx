import { post } from "./ApiService";

const API_URL = 'http://localhost:21089/LoanCalculation/loan/calculateLoan';

export const calculateLoan = async (loanRequest) => {
    try {
        const responseData = await post(API_URL, loanRequest);
        return responseData;
    } catch (error) {
        console.error('Error in Loan calculation:', error);
        throw error;
    }
};