const BASE_URL = 'http://localhost:8080/api/';

export const get = async <T>(path: string): Promise<T[]> => {
  const response = await fetch(BASE_URL + path);
  if (!response.ok) throw new Error("GET request failed");
  const data = await response.json();
  return data;
};

export const getById = async <T>(path: string, id: number): Promise<T> => {
  const response = await fetch(BASE_URL + path + '/' + id);
  if (!response.ok) throw new Error("GET request failed");
  const data = await response.json();
  return data;
};

export const post = async <T>(path: string, data: T): Promise<T> => {
  const response = await fetch(BASE_URL + path, {
    method: 'POST',
    headers: {
      'content-type': 'application/json'
    },
    body: JSON.stringify(data)
  });
  if (!response.ok) throw new Error("GET request failed");
  const responseData = await response.json();
  return responseData;
};
