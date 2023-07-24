const baseUrl = 'https://localhost:5001/api/account/';

export const login = async (userData) => {
    const response = await fetch(`${baseUrl}/login`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(userData)
    });
 
    return response;
};

export const register = async (userData) => {
    const resposnse = await fetch(`${baseUrl}/register`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(userData)
    });

    return resposnse;
};

export const logout = async (token) => {
    await fetch(`${baseUrl}/logout`, {
        method: 'POST',
        headers: {
            'authorization': `Bearer ${token}`,
        },
    });
};

export const getProfile = async (userId, token) => {
    const response = await fetch(`${baseUrl}/${userId}`, {
        method: 'GET',
        headers: {
            'authorization': `Bearer ${token}`,
        },
    });

    const result = response.json();

    return result;
};

export const editProfile = async (userId, userData, token) => {
    const response = await fetch(`${baseUrl}/${userId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
            'authorization': `Bearer ${token}`,
        },
        body: JSON.stringify(userData)
    });

    const result  = response.json();

    return result;
};