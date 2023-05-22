const BASE_URL = 'http://localhost:8080/api/';

export const get = async <T>(path: string): Promise<T[]> => {
  const response = await fetch(BASE_URL + path);
  const data = response.json();
  return data;
};
