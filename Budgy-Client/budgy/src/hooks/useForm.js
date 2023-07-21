import { useState } from "react";

export const useForm = (initialValues, onSubmitHandler) => {
    const [formValues, setFormValues] = useState(initialValues);

    const formChangeHandler = (e) => {
        setFormValues(state => ({ ...state, [e.target.name]: e.target.value }));
    }

    const onSubmit = (e) => {
        e.preventDefault();

        onSubmitHandler(formValues);

        setFormValues(initialValues);
    }

    return {
        formValues,
        formChangeHandler,
        onSubmit,
    };
};