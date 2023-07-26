const baseUrl = 'https://localhost:5001/api/transaction';

export const getAll = async (token) => {
    const response = await fetch(`${baseUrl}`, {
        method: 'GET',
        headers: {
            'content-type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
    });

    const result = await response.json();

    return result.transactions;
};

export const getDetails = async (id, token) => {
    const response = await fetch(`${baseUrl}/all}/${id}`, {
        method: 'GET',
        headers: {
            'content-type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
    });
    

    const result = await response.json();

    return result;
};

export const addTransaction = async (data, token) => {
    const response = await fetch(`${baseUrl}`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringifyd(data)
    });

    const result = await response.json();

    return result;
};

export const editTransaction = async (id, data, token) => {
    const response = await fetch(`${baseUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
            'authorization': `Bearer ${token}`,
        },
        body: JSON.stringify(data)
    });

    const result  = response.json();

    return result;
};

export const deleteTransaction = async (id, token) => {
    const response = await fetch(`${baseUrl}/${id}`, {
        method: 'DELETE',
        headers: {
            'content-type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
    });

    const result = await response.json();

    return result;
};

export const getCategories = async(type, token) => {
    const response = await fetch(`${baseUrl}/categories/${type}`, {
        method: 'GET',
        headers: {
            'content-type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
    });

    const result = await response.json();

    return result.categories;
}