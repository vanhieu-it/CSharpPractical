using System;
using System.Collections.Generic;

public class Document
{
    public string Title { get; set; }
    public string Content { get; set; }
}

class Program
{
    static void Main()
    {
        Dictionary<string, Stack<Document>> documentHistory = new Dictionary<string, Stack<Document>>();

        // Thêm phiên bản tài liệu
        void AddDocumentVersion(string documentId, Document doc)
        {
            if (!documentHistory.ContainsKey(documentId))
            {
                documentHistory[documentId] = new Stack<Document>();
            }
            documentHistory[documentId].Push(doc);
        }

        // Lấy phiên bản tài liệu mới nhất
        Document GetLatestDocumentVersion(string documentId)
        {
            if (documentHistory.ContainsKey(documentId) && documentHistory[documentId].Count > 0)
            {
                return documentHistory[documentId].Peek();
            }
            return null;
        }

        AddDocumentVersion("Doc1", new Document { Title = "Version 1", Content = "Content of version 1" });
        AddDocumentVersion("Doc1", new Document { Title = "Version 2", Content = "Content of version 2" });

        var latestDoc = GetLatestDocumentVersion("Doc1");
        if (latestDoc != null)
        {
            Console.WriteLine($"Latest version of Doc1: {latestDoc.Title} - {latestDoc.Content}");
        }
    }
}
