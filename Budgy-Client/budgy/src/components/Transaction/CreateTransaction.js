import { Form, Button } from "react-bootstrap";
import { useContext, useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useForm } from "../../hooks/useForm";

import * as transactionService from '../../services/transactionService';

import styles from '../Transaction/CreateTransaction.module.css';
import { AuthContext } from "../../contexts/AuthContext";

export const CreateTransaction = () => {

    const { token, userId } = useContext(AuthContext);

    const navigate = useNavigate();

    const [categories, setCategories] = useState([]);

    const [formErrors, setFormErrors] = useState({
        amount: '',
        type: '',
        description: '',
    });

    const onTransactionCreate = async (values) => {
        await transactionService.addTransaction(values, token);
        navigate('/transactions');
    };

    const { formValues, formChangeHandler, onSubmit } = useForm(
        {
            amount: 0.00,
            type: '',
            userId: `${userId}`,
            categoryId: '',
            description: '',
        }, onTransactionCreate);

    const transactionType = formValues.type;

    useEffect(() => {
        transactionService.getCategories(transactionType, token)
            .then(categories => {
                setCategories(categories)
            })
            .catch(error => console.log(error))
    }, [transactionType, token]);

    const transactionFormValidate = (e) => {
        const value = e.target.value;
        const errors = {};

        if (e.target.name === 'amount' && (value <= 0)) {
            errors.content = 'Amoun must cannot be negative or 0';
        }

        if (e.target.name === 'description' && (value.length < 5 || value.length > 100)) {
            errors.content = 'Description should be between 5 and 100 characters';
        }

        setFormErrors(errors);
    }

    return (
        <div className={styles['wrapper']}>
            <Form className={styles['create-form']} onSubmit={onSubmit} method="POST">
            <h3 className={styles['header']}>Register Transaction</h3>
                <Form.Group className={`${styles['make-group']} mb-3`}>
                    <Form.Label className={styles['make-label']}>Amount</Form.Label>
                    <Form.Control type="text"
                        id="amount"
                        name="amount"
                        placeholder="Amount"
                        value={formValues.amount}
                        onChange={formChangeHandler}
                        onBlur={transactionFormValidate} />
                    {formErrors.username &&
                        <p className={`${styles['error']} form-error`}>
                            {formErrors.amount}
                        </p>
                    }
                </Form.Group>
                <Form.Group className={`${styles['make-group']} mb-3`}>
                    <Form.Label className={styles['make-label']}>Type</Form.Label>
                    <Form.Select
                        id="type"
                        name="type"
                        value={formValues.type}
                        onChange={formChangeHandler}
                        onBlur={transactionFormValidate}>
                        <option>Transaction Type</option>
                        <option>Income</option>
                        <option>Expense</option>
                    </Form.Select>
                </Form.Group>
                <Form.Group className={`${styles['make-group']} mb-3`}>
                    <Form.Label className={styles['make-label']}>Category</Form.Label>
                    <Form.Select
                        id="categoryId"
                        name="categoryId"
                        value={formValues.categoryId}
                        onChange={formChangeHandler}
                        onBlur={transactionFormValidate}
                    >
                        <option>Category Type</option>
                        {categories.map((c) => (<option key={c.id} value={c.id}>{c.name}</option>))}
                    </Form.Select>
                </Form.Group>
                <Form.Group className={`${styles['make-group']} mb-3`}>
                    <Form.Label className={styles['make-label']}>Description</Form.Label>
                    <Form.Control type="textarea"
                        id="description"
                        name="description"
                        placeholder="Description"
                        value={formValues.description}
                        onChange={formChangeHandler}
                        onBlur={transactionFormValidate} />
                    {formErrors.username &&
                        <p className={`${styles['error']} form-error`}>
                            {formErrors.description}
                        </p>
                    }
                </Form.Group>
                <Button className={styles['submit-btn']} variant="transparent" type="submit">
                    Make
                </Button>
            </Form>
        </div>
    );
};