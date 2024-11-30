using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAPIServer
{
    class QueryMethods
    {
        public static string Select(string table, string keyName, string key)
        {
            string query = string.Format("SELECT * FROM {0} WHERE {1} = '{2}';", table, keyName, key);

            return query;
        }

        public static string SelectUser(string email, string pw)
        {
            string query = string.Format("SELECT * FROM user WHERE email = '{0}' AND password = '{1}';", email, pw);

            return query;
        }

        public static string SelectStoreByName(string keyName, string key)
        {
            string query = string.Format(@"SELECT * FROM store A
                                        JOIN review B ON A.storeno = B.storeno
                                        WHERE {0} LIKE '%{1}%';", keyName, key);

            return query;
        }

        public static string SelectStoreByCategoryNo(string categoryno)
        {
            string query = string.Format(@"SELECT A.storeno, name, address, categoryno, ROUND(AVG(rating), 1) AS rating FROM store A
                                        JOIN review B ON A.storeno = B.storeno
                                        WHERE categoryno = {0} GROUP BY A.storeno;", categoryno);

            return query;
        }

        public static string InsertReview(string content, string rating, string userno, string stroeno)
        {
            string query = string.Format(@"INSERT INTO review(content, rating, userno, storeno, createdAt, updatedAt)
                                        VALUES('{0}', {1}, {2}, {3}, now(), now());", content, rating, userno, stroeno);

            return query;
        }

        public static string SelectBookmarkByUserNo(string userno)
        {
            string query = string.Format(@"SELECT A.storeno, name, address, categoryno, ROUND(AVG(rating), 1) AS rating FROM store A
                                        JOIN review B ON A.storeno = B.storeno
                                        JOIN bookmark C ON A.storeno = C.storeno
                                        WHERE C.userno = {0} GROUP BY A.storeno;", userno);

            return query;
        }

        public static string InsertBookmark(string userno, string stroeno)
        {
            string query = string.Format(@"INSERT INTO bookmark(userno, storeno, createdAt, updatedAt)
                                        VALUES({0}, {1}, now(), now());", userno, stroeno);

            return query;
        }
    }
}
