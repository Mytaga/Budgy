import { useState, useEffect, useContext } from "react";
import * as transactionService from '../../services/transactionService';
import { Accordion } from "react-bootstrap";
import { AuthContext } from "../../contexts/AuthContext";
import { Transaction } from "../Transaction/Transaction";

export const TransactionList = () => {

    const [transactions, setTransactions] = useState([]);
    const { token } = useContext(AuthContext);

    useEffect(() => {
        transactionService.getAll(token)
            .then(transactions => {
                setTransactions(transactions)
            })
            .catch(error => console.log(error))
    }, [token],);

    return (
        <Accordion>
            {transactions.map((transaction) => (
                <Transaction
                    key={transaction.id}
                    {...transaction}
                />
            ))};
        </Accordion>
    );
};