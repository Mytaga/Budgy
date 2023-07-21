import { createContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useLocalStorage } from "../hooks/useLocalStorage";

import * as accountService from '../services/accountService';

export const AuthContext = createContext();

export const AuthProvider = ({
    children,
}
) => {
    const [auth, setAuth] = useLocalStorage('auth', {});
    const [showError, setShowError] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');

    const onErrorClose = () => {
        setShowError(false);
        setErrorMessage('');
    };

    const navigate = useNavigate();

    const onLogout = async () => {
        await accountService.logout(auth.token);
        setAuth({});
    };

    const onRegisterSubmit = async (data) => {
        const result = await accountService.register(data);

        if (result.status === 201) {
            navigate('/login');
        } else if (result.status === 400) {
            setErrorMessage('Please fill in all the fields');
            setShowError(true);

        } else {
            setErrorMessage('Email already exists in the database!');
            setShowError(true);
        };
    };

    const onLoginSubmit = async (data) => {
        const response = await accountService.login(data);

        if (response.status === 200) {
            const result = await response.json();
            setAuth(result);
            navigate('/');
        }

        setErrorMessage("Credintials don't match!");
        setShowError(true);
    };

    const onBackButtonClick = () => {
        navigate('/');
    };

    const contextValues = {
        onLoginSubmit,
        onRegisterSubmit,
        onLogout,
        onBackButtonClick,
        onErrorClose,
        showError,
        errorMessage,
        setAuth,
        userId: auth.id,
        token: auth.token,
        username: auth.userName,
        firstname: auth.firstName,
        lastname: auth.lastName,
        image: auth.image,
        isAuthenticated: !!auth.token,
    };

    return (
        <>
            <AuthContext.Provider value={contextValues}>
                {children}
            </AuthContext.Provider>
        </>
    );
}