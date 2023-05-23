const BASE_URL = 'http://localhost:8080/api/';

export const getAll = async <T>(path: string): Promise<T[]> => {
  const response = await fetch(BASE_URL + path);
  const data = await response.json();
  return data;
};

export const get = async <T>(path: string, id: number): Promise<T> => {
  const response = await fetch(BASE_URL + path + "/" + id);
  const data = await response.json();
  return data;
}

export const post = async<T>(path: string, data: T): Promise<T> => {
  const response = await fetch(BASE_URL + path, {
    method: 'POST',
    headers: {
      'content-type': 'application/json',
    },
    body: JSON.stringify(data)
  });
  const responseData = await response.json();
  return responseData;
}
