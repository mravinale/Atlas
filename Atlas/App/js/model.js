/* model: entity definitions */
app.factory('model', function () {
    
    var DataType = breeze.DataType; // alias
    
    return {
        initialize: initialize
    };

    function initialize(metadataStore) {
        metadataStore.addEntityType({
            shortName: "Page",
            namespace: "Atlas",
            dataProperties: {
                id: { dataType: DataType.Int64, isPartOfKey: true },
                title: { dataType: DataType.String, isNullable: true },
                postLinks: { dataType: DataType.Undefined }
            },
            navigationProperties: { 
                posts: { entityTypeName: "Post:#Atlas", isScalar: false, associationName: "Page_Posts" }
            }
            // propertyChanged.subscribe(function (changeArgs) { $scope.$apply(); console.log(changeArgs); })
        });

        metadataStore.addEntityType({
            shortName: "Post",
            namespace: "Atlas",
            dataProperties: {
                id: { dataType: DataType.Int32, isNullable: false, isPartOfKey: true },
                name: { dataType: DataType.String, isNullable: true },
                page_id: { dataType: DataType.Int32, isNullable: false }
            },
            navigationProperties: { 
                page: { entityTypeName: "Page:#Atlas", isScalar: true, foreignKeyNames: ["page_id"], associationName: "Page_Posts" },
                comments: { entityTypeName: "Comment:#Atlas", isScalar: false, associationName: "Comment_Posts" }
            }
        });
        
        metadataStore.addEntityType({
            shortName: "Comment",
            namespace: "Atlas",
            dataProperties: {
                id: { dataType: DataType.Int32, isNullable: false, isPartOfKey: true },
                content: { dataType: DataType.String, isNullable: true },
                post_id: { dataType: DataType.Int32, isNullable: false },

            },
            navigationProperties: { 
                post: { entityTypeName: "Post:#Atlas", isScalar: true, associationName: "Comment_Posts", foreignKeyNames: ["post_id"] }
            }
        });

         
    }
})