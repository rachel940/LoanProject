import React, { useState } from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';
import { yupResolver } from '@hookform/resolvers/yup';
import { Container, Paper, TextField, Button, Typography, Box } from '@mui/material';
import { calculateLoan } from '../../services/LoanService';
import './LoanCalculatorForm.css';

const schema = yup.object().shape({
  clientId: yup
    .string()
    .required('Client ID is required')
    .max(9, 'ID number can be maximum 9 digits')
    .matches(/^\d+$/, 'ID number must be only digits'),
  amount: yup
    .number()
    .typeError('Amount must be a number')
    .positive('Amount must be positive')
    .required('Amount is required'),
  periodInMonths: yup
    .number()
    .typeError('Loan period must be a number')
    .min(12, 'Minimum period is 12 months')
    .required('Loan period is required')
});

function LoanCalculatorForm() {
  const { register, handleSubmit, formState: { errors } } = useForm({
    resolver: yupResolver(schema)
  });

  const [result, setResult] = useState(null);
  const [errorMessage, setErrorMessage] = useState(null);

  const onSubmit = async (data) => {
    try {
      const response = await calculateLoan(data);
      setResult(response);
      setErrorMessage(null);
    } catch (error) {
      setErrorMessage('Error calculating loan. Please try again.');
      console.error('Error:', error);
    }
  };

  return (
    <Container component="main" maxWidth="xs" className="container">
      <Paper elevation={3} className="paper">
        <Typography variant="h5" align="center" className="title">Loan Calculator</Typography>
        <form onSubmit={handleSubmit(onSubmit)} className="form-box">
          <TextField
            label="Client ID"
            fullWidth
            variant="outlined"
            {...register('clientId')}
            error={!!errors.clientId}
            helperText={errors.clientId ? errors.clientId.message : ''}
          />
          <TextField
            label="Amount (NIS)"
            type="number"
            fullWidth
            variant="outlined"
            {...register('amount')}
            error={!!errors.amount}
            helperText={errors.amount ? errors.amount.message : ''}
          />
          <TextField
            label="Loan Period (Months)"
            type="number"
            fullWidth
            variant="outlined"
            {...register('periodInMonths')}
            error={!!errors.periodInMonths}
            helperText={errors.periodInMonths ? errors.periodInMonths.message : ''}
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
          >
            Calculate
          </Button>
        </form>
        {result && (
          <Typography variant="h6" className="result-text">
            {result}
          </Typography>
        )}
        {errorMessage && (
          <Typography variant="body1" className="error-text">
            {errorMessage}
          </Typography>
        )}
      </Paper>
    </Container>
  );
}

export default LoanCalculatorForm;
